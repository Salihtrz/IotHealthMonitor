using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelWebUI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
