using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorSurname { get; set; }
        public string? Degree { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? StartingDate { get; set; }
        public bool? Status { get; set; }
        public bool? IsExists { get; set; }
        public int BranchID { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public Branch Branch { get; set; }
    }
}
