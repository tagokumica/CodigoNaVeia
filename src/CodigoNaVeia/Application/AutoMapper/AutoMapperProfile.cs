using Application.ViewModel;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Address, AddressViewModel>()
                .ForMember(c => c.CompanyAddressViewModel, b => b.MapFrom(v => v.CompanyAddress))
                .ReverseMap();

            CreateMap<Company, CompanyViewModel>()
                .ForMember(c => c.EmployeeViewModel, b => b.MapFrom(v => v.Employee))
                .ForMember(c => c.CompanyAddressViewModel, b => b.MapFrom(v => v.CompanyAddress))
                .ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressViewModel>().ReverseMap();
            CreateMap<EmployeeViewModel, EmployeeViewModel>().ReverseMap();



        }
    }
}