using DtoLayer.Dtos.DoctorDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDoctorService : IGenericService<Doctor>
    {
        List<ResultDoctorDto> TGetDoctorsWithBranchName();
        List<ResultDoctorDto> TGetDoctorsStatusTrueWithBranchName();
        List<ResultDoctorDto> TGetDoctorsStatusFalseWithBranchName();
        List<ResultDoctorDto> TGetDoctorsStatusNullWithBranchName();
        void TChangeDoctorStatusToTrue(int id);
        void TChangeDoctorStatusToFalse(int id);
        void TChangeDoctorStatusToNull(int id);
        void TSetDoctorIsExistToFalse(int id);
        GetDoctorDto TGetDoctorIDByAppUserID(int id);
        int TDoctorCountByIsStatusTrue();
    }
}
