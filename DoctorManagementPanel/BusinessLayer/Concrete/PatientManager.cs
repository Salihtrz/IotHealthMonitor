using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.Dtos.PatientDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PatientManager : IPatientService
    {
        private readonly IPatientDal _patientDal;
        private readonly IMapper _mapper;

        public PatientManager(IPatientDal patientDal, IMapper mapper)
        {
            _patientDal = patientDal;
            _mapper = mapper;
        }

        public void TAdd(Patient t)
        {
            _patientDal.Add(t);
        }

        public void TchangePatientStatusToFalse(int id)
        {
            _patientDal.changePatientStatusToFalse(id);
        }

        public void TDelete(Patient t)
        {
            _patientDal.Delete(t);
        }

        public List<Patient> TGetAll()
        {
            return _patientDal.GetAll();
        }

        public Patient TGetByID(int id)
        {
            return _patientDal.GetByID(id);
        }

        public List<ResultPatientDto> TgetPatientsWithStatusTrue()
        {
            var values = _patientDal.getPatientsWithStatusTrue();
            return _mapper.Map<List<ResultPatientDto>>(values);
        }

        public int TPatientCountByStatusTrue()
        {
            var value = _patientDal.PatientCountByStatusTrue();
            return _mapper.Map<int>(value);
        }

        public void TUpdate(Patient t)
        {
            _patientDal.Update(t);
        }
    }
}
