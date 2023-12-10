using AutoMapper;
using AutoMapper.Execution;
using Core.Models;
using E_Commerce.DTOS;

namespace E_Commerce.Helpers
{
    public class ProductURLResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _config;

        public ProductURLResolver(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)) 
            {
                return _config["ApiURL"] +source.PictureUrl;
            }
            return null;
        }
    }
}
