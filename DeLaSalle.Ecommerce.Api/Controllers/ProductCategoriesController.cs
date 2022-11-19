using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DeLaSalle.Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private IProductCategoryRepository _repository;

        public ProductCategoriesController(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<ProductCategoryDto>>>> Get()
        {
            var res = new Response<List<ProductCategoryDto>>();
            var lista = await _repository.GetAllAsync();

            if (lista.Any())
            {
                List<ProductCategoryDto> dtos = lista.Select(c => new ProductCategoryDto(c)).ToList();
                res.Data = dtos;

                return Ok(res);
            }
            return NotFound(res);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Response<ProductCategoryDto>>> Get(int id)
        {
            var res = new Response<ProductCategoryDto>();
            var cat = await _repository.GetById(id);

            ProductCategoryDto dto = new(cat);
            if (dto != null)
            {
                res.Data = dto;
                return Ok(res);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Response<ProductCategoryDto>>> Post([FromBody] ProductCategoryDto categoryDto)
        {
            var res = new Response<ProductCategoryDto>();
            var cat = new ProductCategory();
            cat.Name = categoryDto.Name;
            cat.Description = categoryDto.Description;
            cat.CreatedBy = "";

            cat = await _repository.SaveAsync(cat);
            categoryDto.Id = cat.Id;
            res.Data = categoryDto;

            return CreatedAtAction("Get", new { id = cat.Id }, res);

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id) {
            var res = new Response<bool>();

            res.Data = await _repository.DeleteAsync(id);
            return Ok(res);
        }
    }
}