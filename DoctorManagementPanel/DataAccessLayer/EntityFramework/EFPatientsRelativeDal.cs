using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFPatientsRelativeDal : GenericRepository<PatientsRelative>, IPatientsRelativeDal
    {
        public EFPatientsRelativeDal(DoctorManagementPanelContext context) : base(context)
        {
        }

        public PatientsRelative GetPatientsRelativeIDByAppUserID(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.PatientsRelatives.FirstOrDefault(x => x.AppUserID == id);
            return value;
        }
    }
}
