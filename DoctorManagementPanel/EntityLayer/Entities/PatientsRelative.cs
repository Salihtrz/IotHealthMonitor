using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class PatientsRelative
    {
        public int PatientsRelativeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
