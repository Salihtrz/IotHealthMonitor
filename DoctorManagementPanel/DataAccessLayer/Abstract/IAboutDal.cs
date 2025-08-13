using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAboutDal : IGenericDal<About>
    {
        void changeToStatusTrue(int id);
        void changeToStatusFalse(int id);
        List<About> getAboutWithStatusTrue();
    }
}
