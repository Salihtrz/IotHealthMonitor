using DtoLayer.Dtos.PatientDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPatientService : IGenericService<Patient>
    {
        void TchangePatientStatusToFalse(int id);
        List<ResultPatientDto> TgetPatientsWithStatusTrue();
        int TPatientCountByStatusTrue();
    }
}
