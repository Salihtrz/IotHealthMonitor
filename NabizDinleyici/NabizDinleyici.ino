#include <ESP8266WiFi.h>
#include <PubSubClient.h>
#include <Wire.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

#define OLED_RESET -1
Adafruit_SSD1306 display(128, 64, &Wire, OLED_RESET);

// Wi-Fi Ayarları
//const char* ssid = "zzzz";
//const char* password = "357732Tolga";
const char* ssid = "TP-Link_BAD9";
const char* password = "69724374";

// MQTT Broker (Sanal makinenin IP’si – kendi IP adresinle değiştir)
const char* mqtt_server = "192.168.1.116";  // Örnek IP
WiFiClient espClient;
PubSubClient client(espClient);

// Buzzer pin
#define BUZZER_PIN 12  // D6

int nabiz = -1;
int spo2 = -1;
unsigned long lastMessageTime = 0;
const unsigned long messageTimeout = 7000; // 7 saniye içinde veri gelmezse -1 yap
bool nabizGeldi = false;
bool spo2Geldi = false;
bool ekranGuncelle = false;

void setup_wifi() {
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
  }
  Serial.println("");
  Serial.println("Wi-Fi baglantisi tamamlandi.");
  Serial.print("ESP IP: ");
  Serial.println(WiFi.localIP());
}

void callback(char* topic, byte* payload, unsigned int length) {
  lastMessageTime = millis();

  char msg[10];
  for (int i = 0; i < length && i < 9; i++) {
    msg[i] = (char)payload[i];
  }
  msg[length] = '\0';
  int deger = atoi(msg);

  if (strcmp(topic, "espNabizDinleyici") == 0) {
    nabiz = deger;
    nabizGeldi = true;
  } else if (strcmp(topic, "espSpo2Dinleyici") == 0) {
    spo2 = deger;
    spo2Geldi = true;
  }

  // Her iki veri de gelmişse ekranı güncelle
  if (nabizGeldi && spo2Geldi) {
    ekranGuncelle = true;
    nabizGeldi = false;
    spo2Geldi = false;
  }
}

void reconnect() {
  while (!client.connected()) {
    if (client.connect("ESP8266Dinleyici")) {
      client.subscribe("espNabizDinleyici");
      client.subscribe("espSpo2Dinleyici");
    } else {
      delay(5000);
    }
  }
}

void setup() {
  Serial.begin(115200);
  delay(1000); // seri haberleşmenin başlamasını bekle
  setup_wifi();

  pinMode(BUZZER_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, HIGH); // Sessiz başlat

  // OLED başlat
  Wire.begin();
  if (!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) {
    Serial.println("OLED ekran bulunamadi!");
    while (1);
  }

  display.clearDisplay();
  display.setTextSize(1);
  display.setTextColor(WHITE);
  display.setCursor(0, 0);
  display.println("MQTT baglantisi...");
  display.display();

  client.setServer(mqtt_server, 1883);
  client.setCallback(callback);
}

void loop() {
  if (ekranGuncelle) {
  display.clearDisplay();
  display.setTextSize(1);
  display.setTextColor(WHITE);
  display.setCursor(0, 0);

if (nabiz == -1 && spo2 == -1) {
  display.println("Parmak algilanmadi");
  digitalWrite(BUZZER_PIN, HIGH);
}
else if (nabiz == 0 && spo2 == 0) {
  display.println("Parmak algilanmadi");
  digitalWrite(BUZZER_PIN, HIGH);
}
else if (nabiz == 0 && spo2 > 0) {
  display.setTextSize(2);
  display.setCursor(0, 0);
  display.println("Nabiz: 0");

  display.setTextSize(1);
  display.setCursor(0, 30);
  display.println("Bekleniyor...");
  display.setCursor(0, 45);
  display.print("SpO2: ");
  display.print(spo2);
  display.println(" %");

  digitalWrite(BUZZER_PIN, HIGH);
}
else if (nabiz > 0) {
  display.setTextSize(2);
  display.setCursor(0, 0);
  display.print("Nabiz: ");
  display.println(nabiz);

  display.setTextSize(1);
  display.setCursor(0, 35);
  display.print("SpO2: ");
  display.print(spo2);
  display.println(" %");

  display.setCursor(0, 50);
  if (nabiz < 60) {
    display.println("Bradikardi");
    digitalWrite(BUZZER_PIN, LOW);
  } else if (nabiz > 120) {
    display.println("Tasikardi");
    digitalWrite(BUZZER_PIN, LOW);
  } else {
    display.println("Normal");
    digitalWrite(BUZZER_PIN, HIGH);
  }
}
  display.display();
  ekranGuncelle = false;
}
  if (!client.connected()) {
    reconnect();
  }
  client.loop();
  if (millis() - lastMessageTime > messageTimeout) {
  nabiz = -1;
  spo2 = -1;
}
}