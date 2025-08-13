using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetAll();
        T GetByID(int id);
        void Add(T t);
        void Update(T t);
        void Delete(T t);
    }
}
