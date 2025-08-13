using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagementPanelWebUI.Dtos.PatientsRelativeDtos
{
    public class ResultPatientsRelativeDto
    {
        public int PatientsRelativeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PatientID { get; set; }
        public int AppUserID { get; set; }
        public string? PatientName { get; set; }
        public string? PatientSurname { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Neighborhood { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
    }
}
