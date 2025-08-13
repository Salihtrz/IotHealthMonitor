using AutoMapper;
using DtoLayer.Dtos.AboutDtos;
using EntityLayer.Entities;

namespace DoctorManagementPanelApi.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping() 
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
        }
    }
}
