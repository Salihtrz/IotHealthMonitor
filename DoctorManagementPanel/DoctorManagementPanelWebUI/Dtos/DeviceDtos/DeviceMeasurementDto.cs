using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagementPanelWebUI.Dtos.DeviceDtos
{
    public class DeviceMeasurementDto
    {
        public int DeviceID { get; set; }
        public string? DeviceName { get; set; }
        public string? PatientName { get; set; }
        public string? PatientSurname { get; set; }
        public int? LastPulseValue { get; set; }
        public int? LastSpO2Value { get; set; }
        public DateTime? LastPulseTime { get; set; }
        public DateTime? LastSpO2Time { get; set; }
    }
}
