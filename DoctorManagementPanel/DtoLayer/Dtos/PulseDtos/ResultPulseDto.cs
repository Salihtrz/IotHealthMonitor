using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.PulseDtos
{
    public class ResultPulseDto
    {
        public int ID { get; set; }
        public int PulseValue { get; set; }
        public DateTime Time { get; set; }
        public string DeviceName { get; set; }
        public string PatientName { get; set; }
    }
}
