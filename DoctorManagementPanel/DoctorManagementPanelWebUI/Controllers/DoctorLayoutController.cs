using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelWebUI.Controllers
{
    public class DoctorLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
