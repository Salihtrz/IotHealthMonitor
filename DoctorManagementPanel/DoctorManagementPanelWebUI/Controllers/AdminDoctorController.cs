using DoctorManagementPanelWebUI.Dtos.DoctorDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DoctorManagementPanelWebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class AdminDoctorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDoctorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> DoctorsAwaitingApproval(ResultDoctorDto resultDoctorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Doctor/GetDoctorsStatusNullWithBranchName");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDoctorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ApprovedDoctors(ResultDoctorDto resultDoctorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Doctor/GetDoctorsStatusTrueWithBranchName");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDoctorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RejectedDoctors(ResultDoctorDto resultDoctorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Doctor/GetDoctorsStatusFalseWithBranchName");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDoctorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> changeDoctorStatusToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7254/api/Doctor/ChangeDoctorStatusToTrue?id=" + id);
            return RedirectToAction("ApprovedDoctors");
        }
        [HttpGet]
        public async Task<IActionResult> changeDoctorStatusToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7254/api/Doctor/ChangeDoctorStatusToFalse?id=" + id);
            return RedirectToAction("RejectedDoctors");
        }
        [HttpGet]
        public async Task<IActionResult> changeDoctorStatusToNull(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7254/api/Doctor/ChangeDoctorStatusToNull?id=" + id);
            return RedirectToAction("DoctorsAwaitingApproval");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7254/api/Doctor/SetDoctorIsExistToFalse?id=" + id);
            return RedirectToAction("ApprovedDoctors");
        }
    }
}
