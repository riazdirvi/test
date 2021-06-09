using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using System.Linq;
using AutoMapper;
using API.Helpers;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {

        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(
        IGenericRepository<ProductBrand> brandRepo,
        IGenericRepository<ProductType> typeRepo,
        IGenericRepository<Product> productRepo,
        IMapper mapper)
        {
            _productRepo = productRepo;
            _typeRepo = typeRepo;
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        [HttpGet]
        // public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts(
            // string sort, int? brandId, int? typeId)
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts(
           [FromQuery]ProductSpecParams productParams)
        {
            // var products = await _productRepo.ListAllAsync();

            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            // return Ok(products);

            return Ok(new Pagination<ProductDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            // return await _productRepo.GetByIdAsync(id);

            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            
            if(product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductDto>(product);
        }

        [HttpGet("brands")]

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _brandRepo.ListAllAsync());
        }

        [HttpGet("types")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _typeRepo.ListAllAsync());
        }
    }
}