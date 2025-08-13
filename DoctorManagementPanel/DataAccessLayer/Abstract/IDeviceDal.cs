using DtoLayer.Dtos.DeviceDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDeviceDal : IGenericDal<Device>
    {
        List<Device> GetDeviceWithPatientName();
        List<Device> GetDeviceWithLastMeasurements();
        Device GetDeviceWithLastMeasurementsByDeviceID(int id);
        int GetDeviceWithAveragePulseByDeviceID(int id);
        int GetDeviceWithAverageSpO2ByDeviceID(int id);
        int GetDeviceWithLowestPulseByDeviceID(int id);
        int GetDeviceWithHighestPulseByDeviceID(int id);
        Device GetDeviceIDByPatientID(int id);
        Device GetDeviceWithLowestPulsePatientByDeviceID(int id);
        Device GetDeviceWithHighestPulsePatientByDeviceID(int id);
    }
}
