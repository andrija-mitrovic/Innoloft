using ApplicationCore.DTOs;
using ApplicationCore.Helpers;
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
    public class ProductTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/producttypes
        [HttpGet]
        public async Task<IActionResult> GetProductTypes([FromQuery] PagingParams pagingParams)
        {
            var products = await _unitOfWork.Products.GetProductsWithTypeAndUserAsync(pagingParams);
            var productsDto = _mapper.Map<List<ProductTypeDetailDto>>(products);

            return Ok(productsDto);
        }

        // GET: api/producttypes/1
        [HttpGet("{id}", Name = "GetProductType")]
        public async Task<IActionResult> GetProductType(int id)
        {
            var product = await _unitOfWork.Products.GetProductWithTypeAndUserByIdAsync(id);
            var productDto = _mapper.Map<ProductTypeDetailDto>(product);

            return Ok(productDto);
        }

        // POST: api/producttypes/1
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(ProductTypeCreateDto productTypeCreateDto)
        {
            var productType = _mapper.Map<ProductType>(productTypeCreateDto);

            await _unitOfWork.ProductTypes.AddAsync(productType);

            if (await _unitOfWork.SaveAsync())
            {
                var productToReturn = _mapper.Map<ProductDetailDto>(productType);
                return CreatedAtRoute("GetProductType", new { id = productType.ProductTypeId }, productToReturn);
            }

            throw new Exception("Creating product failed on save");
        }

        // PUT: api/producttypes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductType(int id, ProductTypeUpdateDto productTypeUpdateDto)
        {
            var productType = await _unitOfWork.ProductTypes.GetByIdAsync(id);

            if (productType == null)
                return NotFound();

            _mapper.Map(productTypeUpdateDto, productType);

            _unitOfWork.ProductTypes.Update(productType);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Updating product {id} failed to save");
        }

        // DELETE: api/producttypes/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(int id)
        {
            var productType = await _unitOfWork.ProductTypes.GetByIdAsync(id);

            if (productType == null)
                return NotFound();

            _unitOfWork.ProductTypes.Remove(productType);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Deleting product {id} failed on save");
        }
    }
}
