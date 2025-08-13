using DoctorManagementPanelWebUI.Dtos.DeviceDtos;
using DoctorManagementPanelWebUI.Dtos.PatientDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace DoctorManagementPanelWebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class AdminDeviceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDeviceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> DeviceList(ResultDeviceDto resultDeviceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Device/GetDeviceWithPatientName");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDeviceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateDevice()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Patient/getPatientsWithStatusTrue");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPatientDto>>(jsonData);
                List<SelectListItem> values2 = new List<SelectListItem>
                    {
                        new SelectListItem
                        {
                            Text = "Lütfen bir hasta seçin",
                            Value = "",
                            Selected = true
                        }
                    };

                values2.AddRange(values.Select(x => new SelectListItem
                {
                    Text = x.PatientName,
                    Value = x.PatientID.ToString()
                }));
                ViewBag.Values = values2;
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDevice(CreateDeviceDto createDeviceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDeviceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7254/api/Device", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DeviceList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDevice(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Patient/getPatientsWithStatusTrue");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPatientDto>>(jsonData);
                List<SelectListItem> values2 = new List<SelectListItem>
                    {
                        new SelectListItem
                        {
                            Text = "Lütfen bir hasta seçin",
                            Value = "",
                            Selected = true
                        }
                    };

                values2.AddRange(values.Select(x => new SelectListItem
                {
                    Text = x.PatientName,
                    Value = x.PatientID.ToString()
                }));
                ViewBag.Values = values2;
            }
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:7254/api/Device/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<UpdateDeviceDto>(jsonData2);
                return View(value2);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDevice(UpdateDeviceDto updateDeviceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDeviceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7254/api/Device", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DeviceList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7254/api/Device/" + id);
            return RedirectToAction("DeviceList");
        }
    }
}
