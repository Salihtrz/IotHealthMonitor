using DtoLayer.Dtos.DeviceDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDeviceService : IGenericService<Device>
    {
        List<ResultDeviceDto> TGetDeviceWithPatientName();
        List<DeviceMeasurementDto> TGetDeviceWithLastMeasurements();
        DeviceMeasurementDto TGetDeviceWithLastMeasurementsByDeviceID(int id);
        LowestPulseValueDto TGetDeviceWithLowestPulsePatientByDeviceID(int id);
        HighestPulseValueDto TGetDeviceWithHighestPulsePatientByDeviceID(int id);
        GetDeviceDto TGetDeviceIDByPatientID(int id);
        int TGetDeviceWithAveragePulseByDeviceID(int id);
        int TGetDeviceWithAverageSpO2ByDeviceID(int id);
        int TGetDeviceWithLowestPulseByDeviceID(int id);
        int TGetDeviceWithHighestPulseByDeviceID(int id);
    }
}
