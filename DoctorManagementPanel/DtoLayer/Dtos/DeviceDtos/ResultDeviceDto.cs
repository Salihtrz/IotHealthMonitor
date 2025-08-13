using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.DeviceDtos
{
    public class ResultDeviceDto
    {
        public int DeviceID { get; set; }
        public string? DeviceName { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
    }
}
