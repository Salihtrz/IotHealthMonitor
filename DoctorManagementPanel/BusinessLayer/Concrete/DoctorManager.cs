using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.Dtos.DoctorDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DoctorManager : IDoctorService
    {
        private readonly IDoctorDal _doctorDal;
        private readonly IMapper _mapper;

        public DoctorManager(IDoctorDal doctorDal, IMapper mapper)
        {
            _doctorDal = doctorDal;
            _mapper = mapper;
        }

        public void TAdd(Doctor t)
        {
            _doctorDal.Add(t);
        }

        public void TChangeDoctorStatusToFalse(int id)
        {
            _doctorDal.ChangeDoctorStatusToFalse(id);
        }

        public void TChangeDoctorStatusToNull(int id)
        {
            _doctorDal.ChangeDoctorStatusToNull(id);
        }

        public void TChangeDoctorStatusToTrue(int id)
        {
            _doctorDal.ChangeDoctorStatusToTrue(id);
        }

        public void TDelete(Doctor t)
        {
            _doctorDal.Delete(t);
        }

        public int TDoctorCountByIsStatusTrue()
        {
            var value = _doctorDal.DoctorCountByIsStatusTrue();
            return _mapper.Map<int>(value);
        }

        public List<Doctor> TGetAll()
        {
            return _doctorDal.GetAll();
        }

        public Doctor TGetByID(int id)
        {
            return _doctorDal.GetByID(id);
        }

        public GetDoctorDto TGetDoctorIDByAppUserID(int id)
        {
            var value = _doctorDal.GetDoctorIDByAppUserID(id);
            return _mapper.Map<GetDoctorDto>(value);
        }

        public List<ResultDoctorDto> TGetDoctorsStatusFalseWithBranchName()
        {
            var values = _doctorDal.GetDoctorsStatusFalseWithBranchName();
            return _mapper.Map<List<ResultDoctorDto>>(values);
        }

        public List<ResultDoctorDto> TGetDoctorsStatusNullWithBranchName()
        {
            var values = _doctorDal.GetDoctorsStatusNullWithBranchName();
            return _mapper.Map<List<ResultDoctorDto>>(values);
        }

        public List<ResultDoctorDto> TGetDoctorsStatusTrueWithBranchName()
        {
            var values = _doctorDal.GetDoctorsStatusTrueWithBranchName();
            return _mapper.Map<List<ResultDoctorDto>>(values);
        }

        public List<ResultDoctorDto> TGetDoctorsWithBranchName()
        {
            var values = _doctorDal.GetDoctorsWithBranchName();
            return _mapper.Map<List<ResultDoctorDto>>(values);
        }

        public void TSetDoctorIsExistToFalse(int id)
        {
            _doctorDal.SetDoctorIsExistToFalse(id);
        }

        public void TUpdate(Doctor t)
        {
            _doctorDal.Update(t);
        }
    }
}
