using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using E_Commerce.DTOS;
using E_Commerce.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public IMapper Mapper { get; }

        public ProductsController(IProductRepository productRepository, IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            Mapper = mapper;
        }
        [HttpGet("Product")]
        public async Task<ActionResult<Pagination<ProductDTO>>> Getall([FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductsWithBrandsAndTypesSpecifications(specParams);
            var countSpec = new PRoductWithFilterForCountSpec(specParams);
            var totalItems= await _productRepo.CountAsync(countSpec);
            var list = await _productRepo.ListAsync(spec);
            #region OLD mapping
            //The old mapping
            //var Dto = list.Select(s => new ProductDTO()
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    Description = s.Description,
            //    PictureUrl = s.PictureUrl,
            //    Price = s.Price,
            //    productBrand = s.productBrand.Name,
            //    productType = s.productType.Name
            //}).ToList();
            #endregion
            var data = Mapper.Map<IReadOnlyList<Product>,IReadOnlyList< ProductDTO>>(list);
            return Ok(new Pagination<ProductDTO>(specParams.PageIndex, specParams.PageSize,totalItems,data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var spec = new ProductsWithBrandsAndTypesSpecifications(id);
            var product=await _productRepo.GetEntityWithSpec(spec);
            var map= Mapper.Map<Product,ProductDTO>(product);
            return Ok(map);
            #region old mapping
            //return new ProductDTO()
            //{
            //    Id= product.Id,
            //    Name=product.Name,
            //    Description=product.Description,
            //    PictureUrl=product.PictureUrl,
            //    Price=product.Price,
            //    productBrand=product.productBrand.Name,
            //    productType=product.productType.Name
            //};
            #endregion
        }
        [HttpGet("ProductBrand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetallProductBrand()
        {
            var list = await _productBrandRepo.GetAllAsync();
            return Ok(list);
        }
        [HttpGet("ProductType")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetallProductTypes()
        {
            var list = await _productTypeRepo.GetAllAsync();
            return Ok(list);
        }




    }
}
