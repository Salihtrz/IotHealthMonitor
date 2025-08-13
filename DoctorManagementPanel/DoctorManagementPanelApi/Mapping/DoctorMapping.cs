using AutoMapper;
using DtoLayer.Dtos.DoctorDtos;
using EntityLayer.Entities;

namespace DoctorManagementPanelApi.Mapping
{
    public class DoctorMapping : Profile
    {
        public DoctorMapping()
        {
            CreateMap<Doctor, ResultDoctorDto>().ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName));
            CreateMap<Doctor, UpdateDoctorDto>().ReverseMap();
            CreateMap<Doctor, GetDoctorDto>().ReverseMap();
            CreateMap<Doctor, CreateDoctorDto>().ReverseMap();
        }
    }
}
