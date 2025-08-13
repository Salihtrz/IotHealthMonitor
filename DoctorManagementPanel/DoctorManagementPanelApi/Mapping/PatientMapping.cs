using AutoMapper;
using DtoLayer.Dtos.PatientDtos;
using EntityLayer.Entities;

namespace DoctorManagementPanelApi.Mapping
{
    public class PatientMapping : Profile
    {
        public PatientMapping()
        {
            CreateMap<Patient, ResultPatientDto>().ReverseMap();
            CreateMap<Patient, UpdatePatientDto>().ReverseMap();
            CreateMap<Patient, GetPatientDto>().ReverseMap();
            CreateMap<Patient, CreatePatientDto>().ReverseMap();
        }
    }
}
