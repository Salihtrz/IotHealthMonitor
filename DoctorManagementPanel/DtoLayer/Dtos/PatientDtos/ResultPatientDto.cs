using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.PatientDtos
{
    public class ResultPatientDto
    {
        public int PatientID { get; set; }
        public string? PatientName { get; set; }
        public string? PatientSurname { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Neighborhood { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Imageurl { get; set; }
        public bool? Status { get; set; }
    }
}
