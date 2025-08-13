using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelWebUI.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
