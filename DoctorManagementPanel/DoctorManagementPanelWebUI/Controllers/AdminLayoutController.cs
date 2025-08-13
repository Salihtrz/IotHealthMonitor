using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
