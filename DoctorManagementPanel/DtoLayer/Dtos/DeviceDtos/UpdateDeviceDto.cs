using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.DeviceDtos
{
    public class UpdateDeviceDto
    {
        public int DeviceID { get; set; }
        public string? DeviceName { get; set; }
        public int? PatientID { get; set; }
    }
}
