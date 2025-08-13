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
    public class EFAboutDal : GenericRepository<About>, IAboutDal
    {
        public EFAboutDal(DoctorManagementPanelContext context) : base(context)
        {
        }

        public void changeToStatusFalse(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Abouts.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void changeToStatusTrue(int id)
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Abouts.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public List<About> getAboutWithStatusTrue()
        {
            using var context = new DoctorManagementPanelContext();
            var value = context.Abouts.Where(x => x.Status == true).ToList();
            return value;
        }
    }
}
