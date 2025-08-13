using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.Dtos.AboutDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IMapper _mapper;

        public AboutManager(IAboutDal aboutDal, IMapper mapper)
        {
            _aboutDal = aboutDal;
            _mapper = mapper;
        }

        public void TAdd(About t)
        {
            _aboutDal.Add(t);
        }

        public void TchangeToStatusFalse(int id)
        {
            _aboutDal.changeToStatusFalse(id);
        }

        public void TchangeToStatusTrue(int id)
        {
            _aboutDal.changeToStatusTrue(id);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public List<ResultAboutDto> TgetAboutWithStatusTrue()
        {
            var value = _aboutDal.getAboutWithStatusTrue();
            return _mapper.Map<List<ResultAboutDto>>(value);
        }

        public List<About> TGetAll()
        {
            return _aboutDal.GetAll();
        }

        public About TGetByID(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
