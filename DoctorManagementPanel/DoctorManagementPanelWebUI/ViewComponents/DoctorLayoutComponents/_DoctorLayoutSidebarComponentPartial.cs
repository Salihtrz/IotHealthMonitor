using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoctorManagementPanelWebUI.ViewComponents.DoctorLayoutComponents
{
    public class _DoctorLayoutSidebarComponentPartial : ViewComponent
    {
        private readonly DoctorManagementPanelContext _context;

        public _DoctorLayoutSidebarComponentPartial(DoctorManagementPanelContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = int.Parse(userId);
            if (id != null)
            {
                var user = _context.Doctors.FirstOrDefault(x => x.AppUserID == id);
                ViewBag.DoctorName = user.DoctorName;
                ViewBag.DoctorSurname = user.DoctorSurname;
            }
            return View();
        }
    }
}
