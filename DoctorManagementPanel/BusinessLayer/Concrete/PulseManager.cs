using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.Dtos.PulseDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PulseManager : IPulseService
    {
        private readonly IPulseDal _pulseDal;
        private readonly IMapper _mapper;

        public PulseManager(IPulseDal pulseDal, IMapper mapper)
        {
            _pulseDal = pulseDal;
            _mapper = mapper;
        }

        public void TAdd(Pulse t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Pulse t)
        {
            throw new NotImplementedException();
        }

        public List<Pulse> TGetAll()
        {
            return _pulseDal.GetAll();
        }

        public Pulse TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ResultPulseDto> TGetPulsesByDeviceID(int id)
        {
            var values = _pulseDal.GetPulsesByDeviceID(id);
            return _mapper.Map<List<ResultPulseDto>>(values);
        }

        public List<ResultPulseDto> TGetPulsesWithPatientName()
        {
            var values = _pulseDal.GetPulsesWithPatientName();
            return _mapper.Map<List<ResultPulseDto>>(values);
        }

        public void TUpdate(Pulse t)
        {
            throw new NotImplementedException();
        }
    }
}
