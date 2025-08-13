using DoctorManagementPanelWebUI.Dtos.DeviceDtos;
using DoctorManagementPanelWebUI.Dtos.PatientDtos;

namespace DoctorManagementPanelWebUI.Models
{
    public class AvgPulseAvgSpO2PatientViewModel
    {
        public GetPatientDto Patients { get; set; }
        public int AverageSpO2Value { get; set; }
        public int AveragePulseValue { get; set; }
        public int MaxPulseValue { get; set; }
        public int MinPulseValue { get; set; }
    }
}
