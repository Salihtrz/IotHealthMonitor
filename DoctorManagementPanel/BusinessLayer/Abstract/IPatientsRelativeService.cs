using DtoLayer.Dtos.PatientsRelativeDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPatientsRelativeService : IGenericService<PatientsRelative>
    {
        ResultPatientsRelativeDto TGetPatientsRelativeIDByAppUserID(int id);
    }
}
