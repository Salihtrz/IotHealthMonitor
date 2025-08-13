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
    public class EFSpO2Dal : GenericRepository<SpO2>, ISpO2Dal
    {
        public EFSpO2Dal(DoctorManagementPanelContext context) : base(context)
        {
        }
        public List<SpO2> GetSpO2WithPatientName()
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.SpO2s.Include(x => x.Device).ThenInclude(y => y.Patient).ToList();
            return values;
        }
        public List<SpO2> GetSpO2ByDeviceID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var values = context.SpO2s.Include(x => x.Device).ThenInclude(y => y.Patient).Where(y => y.DeviceID == id).ToList();
            return values;
        }
    }
}
