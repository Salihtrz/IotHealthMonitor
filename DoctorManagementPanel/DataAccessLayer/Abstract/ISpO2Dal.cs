using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISpO2Dal : IGenericDal<SpO2>
    {
        List<SpO2> GetSpO2ByDeviceID(int id);
        List<SpO2> GetSpO2WithPatientName();
    }
}
