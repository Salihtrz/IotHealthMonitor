using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.DeviceDtos
{
    public class LowestPulseValueDto
    {
        public int DeviceID { get; set; }
        public string? DeviceName { get; set; }
        public string? PatientName { get; set; }
        public string? PatientSurname { get; set; }
        public int? LowestPulseValue { get; set; }
    }
}
