using AutoMapper;
using DtoLayer.Dtos.PatientsRelativeDtos;
using EntityLayer.Entities;

namespace DoctorManagementPanelApi.Mapping
{
    public class PatientsRelativeMapping : Profile
    {
        public PatientsRelativeMapping()
        {
            CreateMap<PatientsRelative, ResultPatientsRelativeDto>().ReverseMap();
            CreateMap<PatientsRelative, CreatePatientsRelativeDto>().ReverseMap();
        }
    }
}
