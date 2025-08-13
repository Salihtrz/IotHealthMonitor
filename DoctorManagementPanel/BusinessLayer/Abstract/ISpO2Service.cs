using DtoLayer.Dtos.SpO2Dtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISpO2Service : IGenericService<SpO2>
    {
        List<ResultSpO2Dto> TGetSpO2ByDeviceID(int id);
        List<ResultSpO2Dto> TGetSpO2WithPatientName();
    }
}
