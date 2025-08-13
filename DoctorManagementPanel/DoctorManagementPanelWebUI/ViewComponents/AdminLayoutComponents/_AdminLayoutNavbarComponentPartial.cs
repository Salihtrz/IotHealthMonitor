using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelWebUI.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
