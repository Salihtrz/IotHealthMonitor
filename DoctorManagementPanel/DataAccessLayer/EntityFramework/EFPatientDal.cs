using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFPatientDal : GenericRepository<Patient>, IPatientDal
    {
        public EFPatientDal(DoctorManagementPanelContext context) : base(context)
        {
        }

        public void changePatientStatusToFalse(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Patients.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public List<Patient> getPatientsWithStatusTrue()
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Patients.Where(x => x.Status == true).ToList();
            return value;
        }

        public int PatientCountByStatusTrue()
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Patients.Where(x => x.Status == true).Count();
            return value;
        }
    }
}
