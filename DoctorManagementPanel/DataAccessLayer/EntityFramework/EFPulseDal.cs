using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.Dtos.PulseDtos;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFPulseDal : GenericRepository<Pulse>, IPulseDal
    {
        public EFPulseDal(DoctorManagementPanelContext context) : base(context)
        {
        }
        
        public List<Pulse> GetPulsesWithPatientName()
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Pulses.Include(x => x.Device).ThenInclude(y => y.Patient).ToList();
            return values;
        }

        public List<Pulse> GetPulsesByDeviceID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.Pulses.Include(x => x.Device).ThenInclude(y => y.Patient).Where(y => y.DeviceID == id).ToList();
            return values;
        }
    }
}
