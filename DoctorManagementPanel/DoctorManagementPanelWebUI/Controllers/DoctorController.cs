using DataAccessLayer.Concrete;
using DoctorManagementPanelWebUI.Dtos.DeviceDtos;
using DoctorManagementPanelWebUI.Dtos.DoctorDtos;
using DoctorManagementPanelWebUI.Models;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

namespace DoctorManagementPanelWebUI.Controllers
{
    [Authorize(Roles = "Doctor,Admin")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class DoctorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly DoctorManagementPanelContext _context;

        public DoctorController(IHttpClientFactory httpClientFactory, DoctorManagementPanelContext context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = int.Parse(userId);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Doctor/GetDoctorIDByAppUserID/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                //var jsonData2 = await responseMessage.Content.ReadAsStringAsync();
                //var device = JsonConvert.DeserializeObject<GetDeviceDto>(jsonData2);
                //int deviceID = device.DeviceID;
                //var client3 = _httpClientFactory.CreateClient();
                //var responseMessage3 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceWithAveragePulseByDeviceID/" + deviceID);
                //var responseMessage4 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceWithAverageSpO2ByDeviceID/" + deviceID);
                //var responseMessage5 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceWithHighestPulseByDeviceID/" + deviceID);
                //var responseMessage6 = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceWithLowestPulseByDeviceID/" + deviceID);
                //var responseMessage7 = await client.GetAsync("https://localhost:7254/api/Patient/" + patientID);
                //if (responseMessage3.IsSuccessStatusCode &&
                //    responseMessage4.IsSuccessStatusCode &&
                //    responseMessage5.IsSuccessStatusCode &&
                //    responseMessage6.IsSuccessStatusCode &&
                //    responseMessage7.IsSuccessStatusCode)
                //{
                //    var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                //    var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                //    var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                //    var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                //    var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                //    var deviceAvgPulse = JsonConvert.DeserializeObject<int>(jsonData3);
                //    var deviceAvgSpO2 = JsonConvert.DeserializeObject<int>(jsonData4);
                //    var deviceMaxPulse = JsonConvert.DeserializeObject<int>(jsonData5);
                //    var deviceMinPulse = JsonConvert.DeserializeObject<int>(jsonData6);
                //    var patient = JsonConvert.DeserializeObject<GetPatientDto>(jsonData7);
                //    var model = new AvgPulseAvgSpO2PatientViewModel
                //    {
                //        Patients = patient,
                //        AveragePulseValue = deviceAvgPulse,
                //        AverageSpO2Value = deviceAvgSpO2,
                //        MaxPulseValue = deviceMaxPulse,
                //        MinPulseValue = deviceMinPulse
                //    };
                //    ViewBag.DeviceID = device.DeviceID;
                //    return View(model);
                //}
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(jsonData))
                    return View(); // veya hata view'ı

                var value = JsonConvert.DeserializeObject<GetDoctorDto>(jsonData);

                if (value == null)
                    return View(); // null kontrolü

                return View(value);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PatientList()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = int.Parse(userId);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Doctor/GetDoctorIDByAppUserID/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetDoctorDto>(jsonData);
                ViewBag.Status = value.Status;
                if (value.Status == true)
                {
                    var client2 = _httpClientFactory.CreateClient();
                    var responseMessage2 = await client2.GetAsync("https://localhost:7254/api/Device/GetDeviceWithLastMeasurements");
                    if (responseMessage2.IsSuccessStatusCode)
                    {
                        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                        var values2 = JsonConvert.DeserializeObject<List<DeviceMeasurementDto>>(jsonData2);
                        return View(values2);
                    }
                }
                else
                {
                    ViewBag.Message = "Onay Bekleniyor";
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Charts()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = int.Parse(userId);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Doctor/GetDoctorIDByAppUserID/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetDoctorDto>(jsonData);
                ViewBag.Status = value.Status;
                if (value.Status == true)
                {
                    var client2 = _httpClientFactory.CreateClient();
                    var responseMessage2 = await client2.GetAsync("https://localhost:7254/api/Device/GetDeviceWithLastMeasurements");
                    if (responseMessage2.IsSuccessStatusCode)
                    {
                        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                        var values2 = JsonConvert.DeserializeObject<List<DeviceMeasurementDto>>(jsonData2);
                        return View(values2);
                    }
                }
                else
                {
                    ViewBag.Message = "Onay Bekleniyor";
                    return View();
                }
            }
            return View();
        }
    }
}
