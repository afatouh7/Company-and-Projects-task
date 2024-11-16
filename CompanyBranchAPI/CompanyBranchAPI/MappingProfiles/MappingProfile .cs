using AutoMapper;
using CompanyBranchAPI.Dtos;
using CompanyBranchCore.Entities;

namespace CompanyBranchAPI.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<Branch, BranchsDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
        }
    }
}
