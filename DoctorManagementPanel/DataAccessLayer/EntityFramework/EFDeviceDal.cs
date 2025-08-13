using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDeviceDal : GenericRepository<Device>, IDeviceDal
    {
        public EFDeviceDal(DoctorManagementPanelContext context) : base(context)
        {
        }

        public Device GetDeviceIDByPatientID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Devices.FirstOrDefault(x => x.PatientID == id);
            return value;
        }

        public int GetDeviceWithAveragePulseByDeviceID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Pulses.Average(x => x.PulseValue);
            return (int)values;
        }

        public int GetDeviceWithAverageSpO2ByDeviceID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.SpO2s.Average(x => x.SpO2Value);
            return (int)values;
        }

        public List<Device> GetDeviceWithLastMeasurements()
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Devices.
                Include(x => x.Patient).
                Include(y => y.Pulses).
                Include(z => z.SpO2s).ToList();
            return values;
        }
        public Device GetDeviceWithLastMeasurementsByDeviceID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Devices.
                Include(x => x.Patient).
                Include(y => y.Pulses).
                Include(z => z.SpO2s).FirstOrDefault(x => x.DeviceID == id);
            return values;
        }

        public int GetDeviceWithLowestPulseByDeviceID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Pulses.Where(x => x.PulseValue > 0).Min(x => x.PulseValue);
            return values;
        }

        public List<Device> GetDeviceWithPatientName()
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Devices.Include(x => x.Patient).ToList();
            return values;
        }

        public int GetDeviceWithHighestPulseByDeviceID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Pulses.Max(x => x.PulseValue);
            return values;
        }

        public Device GetDeviceWithLowestPulsePatientByDeviceID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Devices.
                Include(x => x.Patient).
                Include(y => y.Pulses).
                Include(z => z.SpO2s).FirstOrDefault(x => x.DeviceID == id);
            return values;
        }

        public Device GetDeviceWithHighestPulsePatientByDeviceID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Devices.
                Include(x => x.Patient).
                Include(y => y.Pulses).
                Include(z => z.SpO2s).FirstOrDefault(x => x.DeviceID == id);
            return values;
        }
    }
}
