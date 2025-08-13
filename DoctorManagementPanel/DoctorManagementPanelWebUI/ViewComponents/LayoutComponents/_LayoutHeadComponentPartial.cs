using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
