using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagementPanelWebUI.Dtos.PatientsRelativeDtos
{
    public class CreatePatientsRelativeDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PatientID { get; set; }
        public int AppUserID { get; set; }
    }
}
