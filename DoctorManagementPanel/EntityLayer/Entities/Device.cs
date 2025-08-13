using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Device
    {
        public int DeviceID { get; set; }
        public string? DeviceName { get; set; }
        public int? PatientID { get; set; }
        public Patient Patient { get; set; }
        public List<Pulse> Pulses { get; set; }
        public List<SpO2> SpO2s { get; set; }
    }
}
