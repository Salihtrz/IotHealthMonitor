using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDoctorDal : IGenericDal<Doctor>
    {
        List<Doctor> GetDoctorsWithBranchName();
        List<Doctor> GetDoctorsStatusTrueWithBranchName();
        List<Doctor> GetDoctorsStatusFalseWithBranchName();
        List<Doctor> GetDoctorsStatusNullWithBranchName();
        void ChangeDoctorStatusToTrue(int id);
        void ChangeDoctorStatusToFalse(int id);
        void ChangeDoctorStatusToNull(int id);
        void SetDoctorIsExistToFalse(int id);
        Doctor GetDoctorIDByAppUserID(int id);
        int DoctorCountByIsStatusTrue();
    }
}
