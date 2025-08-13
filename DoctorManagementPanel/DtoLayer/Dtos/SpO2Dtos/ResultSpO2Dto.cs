using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SpO2Dtos
{
    public class ResultSpO2Dto
    {
        public int ID { get; set; }
        public int SpO2Value { get; set; }
        public DateTime Time { get; set; }
        public string DeviceName { get; set; }
        public string PatientName { get; set; }
    }
}
