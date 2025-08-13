using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.Dtos.DeviceDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DeviceManager : IDeviceService
    {
        private readonly IDeviceDal _deviceDal;
        private readonly IMapper _mapper;
        public DeviceManager(IDeviceDal deviceDal, IMapper mapper)
        {
            _deviceDal = deviceDal;
            _mapper = mapper;
        }

        public void TAdd(Device t)
        {
            _deviceDal.Add(t);
        }

        public void TDelete(Device t)
        {
            _deviceDal.Delete(t);
        }

        public List<Device> TGetAll()
        {
            return _deviceDal.GetAll();
        }

        public Device TGetByID(int id)
        {
            return _deviceDal.GetByID(id);
        }

        public GetDeviceDto TGetDeviceIDByPatientID(int id)
        {
            var value = _deviceDal.GetDeviceIDByPatientID(id);
            return _mapper.Map<GetDeviceDto>(value);
        }

        public int TGetDeviceWithAveragePulseByDeviceID(int id)
        {
            var value = _deviceDal.GetDeviceWithAveragePulseByDeviceID(id);
            return _mapper.Map<int>(value);
        }

        public int TGetDeviceWithAverageSpO2ByDeviceID(int id)
        {
            var value = _deviceDal.GetDeviceWithAverageSpO2ByDeviceID(id);
            return _mapper.Map<int>(value);
        }

        public int TGetDeviceWithHighestPulseByDeviceID(int id)
        {
            var value = _deviceDal.GetDeviceWithHighestPulseByDeviceID(id);
            return _mapper.Map<int>(value);
        }

        public HighestPulseValueDto TGetDeviceWithHighestPulsePatientByDeviceID(int id)
        {
            var value = _deviceDal.GetDeviceWithHighestPulsePatientByDeviceID(id);
            return _mapper.Map<HighestPulseValueDto>(value);
        }

        public List<DeviceMeasurementDto> TGetDeviceWithLastMeasurements()
        {
            var values = _deviceDal.GetDeviceWithLastMeasurements();
            return _mapper.Map<List<DeviceMeasurementDto>>(values);
        }

        public DeviceMeasurementDto TGetDeviceWithLastMeasurementsByDeviceID(int id)
        {
            var values = _deviceDal.GetDeviceWithLastMeasurementsByDeviceID(id);
            return _mapper.Map<DeviceMeasurementDto>(values);
        }

        public int TGetDeviceWithLowestPulseByDeviceID(int id)
        {
            var value = _deviceDal.GetDeviceWithLowestPulseByDeviceID(id);
            return _mapper.Map<int>(value);
        }

        public LowestPulseValueDto TGetDeviceWithLowestPulsePatientByDeviceID(int id)
        {
            var value = _deviceDal.GetDeviceWithLowestPulsePatientByDeviceID(id);
            return _mapper.Map<LowestPulseValueDto>(value);
        }

        public List<ResultDeviceDto> TGetDeviceWithPatientName()
        {
            var values = _deviceDal.GetDeviceWithPatientName();
            return _mapper.Map<List<ResultDeviceDto>>(values);
        }

        public void TUpdate(Device t)
        {
            _deviceDal.Update(t);
        }
    }
}
