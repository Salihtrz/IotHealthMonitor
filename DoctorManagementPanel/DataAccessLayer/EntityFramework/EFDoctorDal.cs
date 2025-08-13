using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDoctorDal : GenericRepository<Doctor>, IDoctorDal
    {
        public EFDoctorDal(DoctorManagementPanelContext context) : base(context)
        {
        }

        public List<Doctor> GetDoctorsStatusTrueWithBranchName()
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Doctors.Where(x => x.Status == true && x.IsExists == true).Include(y => y.Branch).ToList();
            return values;
        }

        public List<Doctor> GetDoctorsStatusFalseWithBranchName()
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Doctors.Where(x => x.Status == false && x.IsExists == true).Include(y => y.Branch).ToList();
            return values;
        }

        public List<Doctor> GetDoctorsWithBranchName()
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Doctors.Include(x => x.Branch).ToList();
            return values;
        }

        public List<Doctor> GetDoctorsStatusNullWithBranchName()
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Doctors.Where(x => x.Status == null && x.IsExists == true).Include(y => y.Branch).ToList();
            return values;
        }

        public void ChangeDoctorStatusToTrue(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Doctors.FirstOrDefault(x => x.DoctorID == id && x.IsExists == true);
            value.Status = true;
            context.SaveChanges();
        }

        public void ChangeDoctorStatusToFalse(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Doctors.FirstOrDefault(x => x.DoctorID == id && x.IsExists == true);
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeDoctorStatusToNull(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Doctors.FirstOrDefault(x => x.DoctorID == id && x.IsExists == true);
            value.Status = null;
            context.SaveChanges();
        }

        public void SetDoctorIsExistToFalse(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Doctors.FirstOrDefault(x => x.DoctorID == id && x.IsExists == true);
            value.IsExists = false;
            context.SaveChanges();
        }

        public Doctor GetDoctorIDByAppUserID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Doctors.FirstOrDefault(x => x.AppUserID == id && x.IsExists == true);
            return value;
        }

        public int DoctorCountByIsStatusTrue()
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Doctors.Where(x => x.Status == true).Count();
            return value;
        }
    }
}
