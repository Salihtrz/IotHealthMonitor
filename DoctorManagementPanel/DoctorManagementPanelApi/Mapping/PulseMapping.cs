using AutoMapper;
using DtoLayer.Dtos.PulseDtos;
using EntityLayer.Entities;

namespace DoctorManagementPanelApi.Mapping
{
    public class PulseMapping : Profile
    {
        public PulseMapping()
        {
            CreateMap<Pulse, ResultPulseDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Device.Patient.PatientName))
                .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.Device.DeviceName));
        }
    }
}
