using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelWebUI.ViewComponents.DoctorLayoutComponents
{
    public class _DoctorLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
