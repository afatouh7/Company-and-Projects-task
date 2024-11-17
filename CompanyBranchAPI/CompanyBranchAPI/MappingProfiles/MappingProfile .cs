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
            CreateMap<Branch, GetBranchDto>()
                 .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company.Name))
                 .ReverseMap();

            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
        }
    }
}
