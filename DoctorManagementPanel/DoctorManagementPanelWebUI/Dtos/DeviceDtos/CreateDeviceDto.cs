using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagementPanelWebUI.Dtos.DeviceDtos
{
    public class CreateDeviceDto
    {
        public string? DeviceName { get; set; }
        public int? PatientID { get; set; }
    }
}
