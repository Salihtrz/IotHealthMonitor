using AutoMapper;
using DtoLayer.Dtos.SpO2Dtos;
using EntityLayer.Entities;

namespace DoctorManagementPanelApi.Mapping
{
    public class SpO2Mapping : Profile
    {
        public SpO2Mapping()
        {
            CreateMap<SpO2, ResultSpO2Dto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Device.Patient.PatientName))
                .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.Device.DeviceName));
        }
    }
}
