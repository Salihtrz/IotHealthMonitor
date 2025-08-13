using DoctorManagementPanelWebUI.Dtos.AboutDtos;
using DoctorManagementPanelWebUI.Dtos.DoctorDtos;

namespace DoctorManagementPanelWebUI.Models
{
    public class DoctorAboutViewModel
    {
        public List<ResultAboutDto> Abouts { get; set; }
        public List<ResultDoctorDto> Doctors { get; set; }
    }
}
