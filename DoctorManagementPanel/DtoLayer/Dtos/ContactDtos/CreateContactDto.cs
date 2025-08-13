using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
    }
}
