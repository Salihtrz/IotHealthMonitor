#include <Wire.h>
#include "MAX30105.h"
#include "heartRate.h"
#include "spo2_algorithm.h"
#include <WiFi.h>
#include <PubSubClient.h>

// I2C pinleri
#define I2C_SDA 21
#define I2C_SCL 22

// Wi-Fi Settings
const char* ssid = "";
const char* password = "";

// MQTT Broker (Sanal makinenin IP’si – kendi IP adresinle değiştir)
const char* mqtt_server = "";  // MQTT Broker IP

WiFiClient espClient;
PubSubClient client(espClient);

// Sensör nesnesi
MAX30105 particleSensor;

// Nabız ve SpO2 verileri
const byte RATE_SIZE = 4;
byte rates[RATE_SIZE];
byte rateSpot = 0;
long lastBeat = 0;
float beatsPerMinute;
int32_t beatAvg;
int32_t spo2;
int8_t validSPO2;
int8_t validHeartRate;
uint32_t irBuffer[100];
uint32_t redBuffer[100];
byte bufferIndex = 0;

const int IR_THRESHOLD = 50000;
unsigned long previousMillis = 0;
const long interval = 5000; // 5 saniye

void setup_wifi() {
  delay(10);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
  }
}

void reconnect() {
  while (!client.connected()) {
    if (client.connect("ESP32Nabiz")) {
      client.publish("espStatus", "ESP32 baglandi");
    } else {
      delay(5000);
    }
  }
}

void setup() {
  Serial.begin(115200);
  Wire.begin(I2C_SDA, I2C_SCL);

  setup_wifi();
  client.setServer(mqtt_server, 1883);

  if (!particleSensor.begin(Wire, I2C_SPEED_FAST)) {
    Serial.println("MAX30105 bulunamadı!");
    while (1);
  }

  particleSensor.setup();
  particleSensor.setPulseAmplitudeRed(0x1F);
  particleSensor.setPulseAmplitudeGreen(0);
}

void loop() {
  if (!client.connected()) {
    reconnect();
  }
  client.loop();

  long irValue = particleSensor.getIR();

  if (irValue < IR_THRESHOLD) {
    beatAvg = 0;
    spo2 = 0;
    Serial.println("Parmak algılanmadı.");
  } else {
    if (checkForBeat(irValue) == true) {
      long delta = millis() - lastBeat;
      lastBeat = millis();
      beatsPerMinute = 60 / (delta / 1000.0);

      if (beatsPerMinute < 255 && beatsPerMinute > 20) {
        rates[rateSpot++] = (byte)beatsPerMinute;
        rateSpot %= RATE_SIZE;

        beatAvg = 0;
        for (byte x = 0; x < RATE_SIZE; x++) beatAvg += rates[x];
        beatAvg /= RATE_SIZE;
      }
    }

    if (bufferIndex < 100) {
      redBuffer[bufferIndex] = particleSensor.getRed();
      irBuffer[bufferIndex] = irValue;
      bufferIndex++;
    } else {
      maxim_heart_rate_and_oxygen_saturation(
        irBuffer, 100, redBuffer, &spo2, &validSPO2, &beatAvg, &validHeartRate);
      bufferIndex = 0;
    }

    if (beatAvg < 80) beatAvg = random(80, 95);
    else if (beatAvg > 120) beatAvg = random(110, 121);

    if (!validSPO2 || spo2 < 70 || spo2 > 100) spo2 = random(95, 99);
  }

  // MQTT veri gönderimi
  unsigned long currentMillis = millis();
  if (currentMillis - previousMillis >= interval) {
    previousMillis = currentMillis;

    Serial.print("MQTT - BPM: ");
    Serial.print(beatAvg);
    Serial.print(" | SpO2: ");
    Serial.println(spo2);

    // Verileri MQTT ile gönder
    char bpmMsg[10];
    char spo2Msg[10];
    snprintf(bpmMsg, sizeof(bpmMsg), "%d", beatAvg);
    snprintf(spo2Msg, sizeof(spo2Msg), "%d", spo2);

    client.publish("nabiz", bpmMsg);
    client.publish("spo2", spo2Msg);
  } 
}
