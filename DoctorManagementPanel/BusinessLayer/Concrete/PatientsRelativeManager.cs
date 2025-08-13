using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.Dtos.PatientsRelativeDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PatientsRelativeManager : IPatientsRelativeService
    {
        private readonly IPatientsRelativeDal _patientsRelativeDal;
        private readonly IMapper _mapper;

        public PatientsRelativeManager(IPatientsRelativeDal patientsRelativeDal, IMapper mapper)
        {
            _patientsRelativeDal = patientsRelativeDal;
            _mapper = mapper;
        }

        public void TAdd(PatientsRelative t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(PatientsRelative t)
        {
            throw new NotImplementedException();
        }

        public List<PatientsRelative> TGetAll()
        {
            throw new NotImplementedException();
        }

        public PatientsRelative TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public ResultPatientsRelativeDto TGetPatientsRelativeIDByAppUserID(int id)
        {
            var value = _patientsRelativeDal.GetPatientsRelativeIDByAppUserID(id);
            return _mapper.Map<ResultPatientsRelativeDto>(value);
        }

        public void TUpdate(PatientsRelative t)
        {
            throw new NotImplementedException();
        }
    }
}
