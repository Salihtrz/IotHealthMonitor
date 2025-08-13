using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.BranchDtos
{
    public class UpdateBranchDto
    {
        public int BranchID { get; set; }
        public string? BranchName { get; set; }
    }
}
