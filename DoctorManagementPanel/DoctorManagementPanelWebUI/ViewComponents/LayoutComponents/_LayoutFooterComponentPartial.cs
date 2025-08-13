using Microsoft.AspNetCore.Mvc;

namespace DoctorManagementPanelWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
