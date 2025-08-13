using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoctorManagementPanelWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarComponentPartial : ViewComponent
    {
        private readonly DoctorManagementPanelContext _context;

        public _LayoutSidebarComponentPartial(DoctorManagementPanelContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = int.Parse(userId);
            if(id != null)
            {
                var user = _context.PatientsRelatives.FirstOrDefault(x => x.AppUserID == id);
                ViewBag.RelativeName = user.Name;
                ViewBag.RelativeSurname = user.Surname;
            }
            return View();
        }
    }
}
