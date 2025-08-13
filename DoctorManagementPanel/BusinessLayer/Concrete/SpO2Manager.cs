using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.Dtos.SpO2Dtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SpO2Manager : ISpO2Service
    {
        private readonly ISpO2Dal _spO2Dal;
        private readonly IMapper _mapper;
        public SpO2Manager(ISpO2Dal spO2Dal, IMapper mapper)
        {
            _spO2Dal = spO2Dal;
            _mapper = mapper;
        }

        public void TAdd(SpO2 t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(SpO2 t)
        {
            throw new NotImplementedException();
        }

        public List<SpO2> TGetAll()
        {
            return _spO2Dal.GetAll();
        }

        public SpO2 TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ResultSpO2Dto> TGetSpO2ByDeviceID(int id)
        {
            var values = _spO2Dal.GetSpO2ByDeviceID(id);
            return _mapper.Map<List<ResultSpO2Dto>>(values);
        }

        public List<ResultSpO2Dto> TGetSpO2WithPatientName()
        {
            var values = _spO2Dal.GetSpO2WithPatientName();
            return _mapper.Map<List<ResultSpO2Dto>>(values);
        }

        public void TUpdate(SpO2 t)
        {
            throw new NotImplementedException();
        }
    }
}
