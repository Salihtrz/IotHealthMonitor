using DataAccessLayer.Concrete;
using DoctorManagementPanelWebUI.Dtos.DeviceDtos;
using DoctorManagementPanelWebUI.Dtos.PatientDtos;
using DoctorManagementPanelWebUI.Dtos.PatientsRelativeDtos;
using DoctorManagementPanelWebUI.Models;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;

namespace DoctorManagementPanelWebUI.Controllers
{
    [Authorize(Roles = "Patient,Admin")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class PatientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly DoctorManagementPanelContext _context;

        public PatientController(IHttpClientFactory httpClientFactory, DoctorManagementPanelContext context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = int.Parse(userId);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/PatientsRelative/GetPatientsRelativeIDByAppUserID/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var patientRelative = JsonConvert.DeserializeObject<ResultPatientsRelativeDto>(jsonData);
                int patientID = patientRelative.PatientID;
                ViewBag.RelativeName = patientRelative.Name;
                ViewBag.RelativeSurname = patientRelative.Surname;
                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceIDByPatientID/" + patientID);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var device = JsonConvert.DeserializeObject<GetDeviceDto>(jsonData2);
                    int deviceID = device.DeviceID;
                    var client3 = _httpClientFactory.CreateClient();
                    var responseMessage3 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceWithAveragePulseByDeviceID/" + deviceID);
                    var responseMessage4 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceWithAverageSpO2ByDeviceID/" + deviceID);
                    var responseMessage5 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceWithHighestPulseByDeviceID/" + deviceID);
                    var responseMessage6 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceWithLowestPulseByDeviceID/" + deviceID);
                    var responseMessage7 = await client.GetAsync("https://localhost:7254/api/Patient/" + patientID);
                    if (responseMessage3.IsSuccessStatusCode && 
                        responseMessage4.IsSuccessStatusCode && 
                        responseMessage5.IsSuccessStatusCode &&
                        responseMessage6.IsSuccessStatusCode &&
                        responseMessage7.IsSuccessStatusCode)
                    {
                        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                        var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                        var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                        var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                        var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                        var deviceAvgPulse = JsonConvert.DeserializeObject<int>(jsonData3);
                        var deviceAvgSpO2 = JsonConvert.DeserializeObject<int>(jsonData4);
                        var deviceMaxPulse = JsonConvert.DeserializeObject<int>(jsonData5);
                        var deviceMinPulse = JsonConvert.DeserializeObject<int>(jsonData6);
                        var patient = JsonConvert.DeserializeObject<GetPatientDto>(jsonData7);
                        var model = new AvgPulseAvgSpO2PatientViewModel
                        {
                            Patients = patient,
                            AveragePulseValue = deviceAvgPulse,
                            AverageSpO2Value = deviceAvgSpO2,
                            MaxPulseValue = deviceMaxPulse,
                            MinPulseValue = deviceMinPulse
                        };
                        ViewBag.DeviceID = device.DeviceID;
                        return View(model);
                    }
                }
            }

            return View(); // hata durumu
        }
        [HttpGet]
        public async Task<IActionResult> Charts()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = int.Parse(userId);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/PatientsRelative/GetPatientsRelativeIDByAppUserID/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var patientRelative = JsonConvert.DeserializeObject<ResultPatientsRelativeDto>(jsonData);
                int patientID = patientRelative.PatientID;
                ViewBag.RelativeName = patientRelative.Name;
                ViewBag.RelativeSurname = patientRelative.Surname;
                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceIDByPatientID/" + patientID);
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    var device = JsonConvert.DeserializeObject<GetDeviceDto>(jsonData2);
                    int deviceID = device.DeviceID;
                    var client3 = _httpClientFactory.CreateClient();
                    var responseMessage3 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceWithLastMeasurementsByDeviceID/" + deviceID);
                    if (responseMessage3.IsSuccessStatusCode)
                    {
                        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                        var deviceMeasurements = JsonConvert.DeserializeObject<DeviceMeasurementDto>(jsonData3);
                        ViewBag.DeviceID = device.DeviceID;
                        return View(deviceMeasurements);
                    }
                }
            }
            return View();
        }
    }
}
