using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelWebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
