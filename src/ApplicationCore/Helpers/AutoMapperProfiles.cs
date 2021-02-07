using ApplicationCore.DTOs;
using ApplicationCore.Models;
using AutoMapper;

namespace ApplicationCore.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDetailDto>()
                .ForMember(dest => dest.ContactPerson, opt => {
                    opt.MapFrom(src => src.User);
                });
            CreateMap<Product, ProductListDto>()
                .ForMember(dest => dest.ContactPerson, opt => {
                    opt.MapFrom(src => src.User);
                });
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

            CreateMap<ProductType, ProductTypeDetailDto>();

            CreateMap<User, UserDetailDto>();
            CreateMap<User, UserListDto>();

            CreateMap<Address, AddressDetailDto>();

            CreateMap<Company, CompanyDetailDto>();

            CreateMap<Geo, GeoDetailDto>();
        }
    }
}
