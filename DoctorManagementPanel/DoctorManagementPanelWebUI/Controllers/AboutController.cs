using DoctorManagementPanelWebUI.Dtos.AboutDtos;
using DoctorManagementPanelWebUI.Dtos.DoctorDtos;
using DoctorManagementPanelWebUI.Models;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DoctorManagementPanelWebUI.Controllers
{
    
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Authorize(Roles = "Doctor,Admin")]
        [HttpGet]
        public async Task<IActionResult> DoctorAbout()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/About/getAboutWithStatusTrue");
            var responseMessage2 = await client.GetAsync("https://localhost:7254/api/Doctor/GetDoctorsWithBranchName");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var abouts = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                var doctors = JsonConvert.DeserializeObject<List<ResultDoctorDto>>(jsonData2);
                var model = new DoctorAboutViewModel
                {
                    Abouts = abouts,
                    Doctors = doctors
                };
                return View(model);
            }
            return View();
        }
        [Authorize(Roles = "Patient,Admin")]
        [HttpGet]
        public async Task<IActionResult> PatientAbout()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/About/getAboutWithStatusTrue");
            var responseMessage2 = await client.GetAsync("https://localhost:7254/api/Doctor/GetDoctorsWithBranchName");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var abouts = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                var doctors = JsonConvert.DeserializeObject<List<ResultDoctorDto>>(jsonData2);
                var model = new DoctorAboutViewModel
                {
                    Abouts = abouts,
                    Doctors = doctors
                };
                return View(model);
            }
            return View();
        }
    }
}
