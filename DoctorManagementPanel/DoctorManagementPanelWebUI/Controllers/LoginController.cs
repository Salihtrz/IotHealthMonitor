using DoctorManagementPanelWebUI.Dtos.LoginDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagementPanelWebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin(AdminLoginDto adminLoginDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Name == adminLoginDto.Name
            && x.Surname == adminLoginDto.Surname);
            if(user != null)
            {
                var passwordValid = await _userManager.CheckPasswordAsync(user, adminLoginDto.Password);
                if (passwordValid)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("AboutList", "AdminAbout");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult DoctorLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DoctorLogin(DoctorLoginDto doctorLoginDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Name == doctorLoginDto.Name
            && x.Surname == doctorLoginDto.Surname);
            if (user != null)
            {
                var passwordValid = await _userManager.CheckPasswordAsync(user, doctorLoginDto.Password);
                if (passwordValid)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Doctor");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult PatientRelativeLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PatientRelativeLogin(PatientRelativeLoginDto patientRelativeLoginDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Name == patientRelativeLoginDto.Name
            && x.Surname == patientRelativeLoginDto.Surname);
            if (user != null)
            {
                var passwordValid = await _userManager.CheckPasswordAsync(user, patientRelativeLoginDto.Password);
                if (passwordValid)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Patient");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
            return RedirectToAction("Index", "Login");
        }
    }
}
