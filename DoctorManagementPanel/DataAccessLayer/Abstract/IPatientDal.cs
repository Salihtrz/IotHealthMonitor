using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPatientDal : IGenericDal<Patient>
    {
        void changePatientStatusToFalse(int id);
        List<Patient> getPatientsWithStatusTrue();
        int PatientCountByStatusTrue();
    }
}
