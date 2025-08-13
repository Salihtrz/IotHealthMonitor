using AutoMapper;
using DtoLayer.Dtos.BranchDtos;
using EntityLayer.Entities;

namespace DoctorManagementPanelApi.Mapping
{
    public class BranchMapping : Profile
    {
        public BranchMapping() 
        {
            CreateMap<Branch, ResultBranchDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
            CreateMap<Branch, GetBranchDto>().ReverseMap();
            CreateMap<Branch, CreateBranchDto>().ReverseMap();
        }
    }
}
