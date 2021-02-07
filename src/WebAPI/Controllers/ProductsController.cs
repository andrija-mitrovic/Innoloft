using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _unitOfWork.Products.GetProductsWithTypeAndUserAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDetailDto>>(products);

            return Ok(productsDto);
        }

        //// GET: api/products
        //[HttpGet]
        //public async Task<IActionResult> GetProducts([FromQuery] PagingParams pagingParams)
        //{
        //    var products = await _unitOfWork.Products.GetProductsWithTypeAndUserAsync(pagingParams);
        //    //var productsDto = _mapper.Map<IEnumerable<ProductDetailDto>>(products);
        //    var productsDto = _mapper.Map<IEnumerable<ProductListDto>>(products);

        //    return Ok(productsDto);
        //}

        // GET: api/products/1
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _unitOfWork.Products.GetProductWithTypeAndUserByIdAsync(id);
            var productDto = _mapper.Map<ProductDetailDto>(product);

            return Ok(productDto);
        }

        // POST: api/products/1
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);

            await _unitOfWork.Products.AddAsync(product);

            if (await _unitOfWork.SaveAsync())
            {
                var productToReturn = _mapper.Map<ProductDetailDto>(product);
                return CreatedAtRoute("GetProduct", new { id = product.ProductId }, productToReturn);
            }

            throw new Exception("Creating product failed on save");
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, ProductUpdateDto productUpdateDto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            _mapper.Map(productUpdateDto, product);

            _unitOfWork.Products.Update(product);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Updating product {id} failed to save");
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            _unitOfWork.Products.Remove(product);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Deleting product {id} failed on save");
        }
    }
}
