using DataAccessLayer.Concrete;
using DoctorManagementPanelWebUI.Dtos.BranchDtos;
using DoctorManagementPanelWebUI.Dtos.PatientDtos;
using DoctorManagementPanelWebUI.Dtos.RegisterDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DoctorManagementPanelWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DoctorManagementPanelContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(UserManager<AppUser> userManager, DoctorManagementPanelContext context, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _context = context;
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> DoctorRegister()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Branch");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBranchDto>>(jsonData);
                List<SelectListItem> values2 = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.BranchName,
                                                    Value = x.BranchID.ToString()
                                                }).ToList();
                ViewBag.Values = values2;
                return View();
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> DoctorRegister(DoctorRegisterDto doctorRegisterDto)
        {
            var appuser = new AppUser()
            {
                Name = doctorRegisterDto.Name,
                Surname = doctorRegisterDto.Surname,
                Email = doctorRegisterDto.Email,
                PhoneNumber = doctorRegisterDto.Phone,
                UserName = doctorRegisterDto.Name + doctorRegisterDto.Surname
            };
            var result = await _userManager.CreateAsync(appuser, doctorRegisterDto.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appuser, "Doctor");
                var doctor = new Doctor()
                {
                    DoctorName = doctorRegisterDto.Name,
                    DoctorSurname = doctorRegisterDto.Surname,
                    Email = doctorRegisterDto.Email,
                    Phone = doctorRegisterDto.Phone,
                    AppUserID = appuser.Id,
                    Status = null,
                    IsExists = true,
                    BranchID = doctorRegisterDto.BranchID,
                    Degree = doctorRegisterDto.Degree
                };
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction("AdminLogin", "Login");
            }
            return View();
        }
        [Authorize(Policy = "DenyAll")]
        [HttpGet]
        public IActionResult AdminRegister()
        {
            return View();
        }
        [Authorize(Policy = "DenyAll")]
        [HttpPost]
        public async Task<IActionResult> AdminRegister(AdminRegisterDto adminRegisterDto)
        {
            var appuser = new AppUser()
            {
                Name = adminRegisterDto.Name,
                Surname = adminRegisterDto.Surname,
                UserName = adminRegisterDto.Name + adminRegisterDto.Surname
            };
            var result = await _userManager.CreateAsync(appuser, adminRegisterDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appuser, "Admin");
                return RedirectToAction("AdminLogin", "Login");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> PatientRelativeRegister()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7254/api/Patient/getPatientsWithStatusTrue");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPatientDto>>(jsonData);
                List<SelectListItem> values2 = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.PatientName,
                                                    Value = x.PatientID.ToString()
                                                }).ToList();
                ViewBag.Values = values2;
                return View();
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PatientRelativeRegister(PatientRelativeRegisterDto patientRelativeRegisterDto)
        {
            var appuser = new AppUser()
            {
                Name = patientRelativeRegisterDto.Name,
                Surname = patientRelativeRegisterDto.Surname,
                UserName = patientRelativeRegisterDto.Name + patientRelativeRegisterDto.Surname
            };
            var result = await _userManager.CreateAsync(appuser, patientRelativeRegisterDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appuser, "Patient");
                var patientsRelative = new PatientsRelative()
                {
                    PatientID = patientRelativeRegisterDto.PatientID,
                    Name = patientRelativeRegisterDto.Name,
                    Surname = patientRelativeRegisterDto.Surname,
                    AppUserID = appuser.Id
                };
                _context.PatientsRelatives.Add(patientsRelative);
                await _context.SaveChangesAsync();
                return RedirectToAction("PatientRelativeLogin", "Login");
            }
            return View();
        }
    }
}
