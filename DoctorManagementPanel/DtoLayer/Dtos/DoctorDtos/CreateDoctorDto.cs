using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.DoctorDtos
{
    public class CreateDoctorDto
    {
        public string? DoctorName { get; set; }
        public string? DoctorSurname { get; set; }
        public string? Degree { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? StartingDate { get; set; }
        public bool? Status { get; set; }
        public bool? IsExists { get; set; }
        public int BranchID { get; set; }
    }
}
