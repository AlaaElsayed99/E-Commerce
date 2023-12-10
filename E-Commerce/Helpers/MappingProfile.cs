using AutoMapper;
using Core.Models;
using E_Commerce.DTOS;

namespace E_Commerce.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(d => d.productType, o => o.MapFrom(s => s.productType.Name))
                .ForMember(d => d.productBrand, o => o.MapFrom(s => s.productBrand.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductURLResolver>());
                
               
        }
    }
}
