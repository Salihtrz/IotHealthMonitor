using AutoMapper;
using DtoLayer.Dtos.DeviceDtos;
using EntityLayer.Entities;

namespace DoctorManagementPanelApi.Mapping
{
    public class DeviceMapping : Profile
    {
        public DeviceMapping()
        {
            CreateMap<Device, ResultDeviceDto>()
                .ForMember(dest => dest.PatientSurname, opt => opt.MapFrom(src => src.Patient.PatientSurname))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.PatientName));
            CreateMap<Device, UpdateDeviceDto>().ReverseMap();
            CreateMap<Device, GetDeviceDto>().ReverseMap();
            CreateMap<Device, CreateDeviceDto>().ReverseMap();
            CreateMap<Device, DeviceMeasurementDto>()
                .ForMember(dest => dest.PatientSurname, opt => opt.MapFrom(src => src.Patient.PatientSurname))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.PatientName))
                .ForMember(dest => dest.LastPulseValue, opt => opt.MapFrom(src =>
                    src.Pulses.OrderByDescending(p => p.Time)
                            .Select(p => (int?)p.PulseValue)
                            .FirstOrDefault()
                            ))
                .ForMember(dest => dest.LastSpO2Value, opt => opt.MapFrom(src =>
                    src.SpO2s.OrderByDescending(s => s.Time)
                            .Select(s => (int?)s.SpO2Value)
                            .FirstOrDefault()
                            ))
                .ForMember(dest => dest.LastPulseTime, opt => opt.MapFrom(src =>
                    src.Pulses.OrderByDescending(p => p.Time)
                            .Select(p => (DateTime?)p.Time)
                            .FirstOrDefault()
                            ))
                .ForMember(dest => dest.LastSpO2Time, opt => opt.MapFrom(src =>
                    src.SpO2s.OrderByDescending(s => s.Time)
                            .Select(s => (DateTime?)s.Time)
                            .FirstOrDefault()
                            ));
            CreateMap<Device, LowestPulseValueDto>()
                .ForMember(dest => dest.PatientSurname, opt => opt.MapFrom(src => src.Patient.PatientSurname))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.PatientName))
                .ForMember(dest => dest.LowestPulseValue, opt => opt.MapFrom(src =>
                    src.Pulses.OrderBy(p => p.PulseValue)
                            .Where(p => p.PulseValue > 0)
                            .Select(p => (int?)p.PulseValue)
                            .FirstOrDefault()
                            ));
            CreateMap<Device,HighestPulseValueDto>()
                .ForMember(dest => dest.PatientSurname, opt => opt.MapFrom(src => src.Patient.PatientSurname))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.PatientName))
                .ForMember(dest => dest.HighestPulseValue, opt => opt.MapFrom(src =>
                    src.Pulses.OrderByDescending(p => p.PulseValue)
                            .Select(p => (int?)p.PulseValue)
                            .FirstOrDefault()
                            ));
        }
    }
}
