using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class SpO2
    {
        public int ID { get; set; }
        public int SpO2Value { get; set; }
        public DateTime Time { get; set; }
        public int DeviceID { get; set; }
        public Device Device { get; set; }
    }
}
