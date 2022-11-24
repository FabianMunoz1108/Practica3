using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private IProductCategoryService _service;

        public ProductCategoriesController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<ProductCategoryDto>>>> Get()
        {
            var res = new Response<List<ProductCategoryDto>>()
            {
                Data = await _service.GetAllAsync()
            };
            return Ok(res);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Response<ProductCategoryDto>>> Get(int id)
        {
            var res = new Response<ProductCategoryDto>();

            if (!await _service.ProductCategoryExists(id))
            {
                res.Errors.Add("No encontrado");
                return NotFound(res);
            }
            res.Data = await _service.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Response<ProductCategoryDto>>> Post([FromBody] ProductCategoryDto categoryDto)
        {
            var res = new Response<ProductCategoryDto>()
            {
                Data = await _service.SaveAsync(categoryDto)
            };
            return CreatedAtAction("Get", new { id = res.Data.Id }, res);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            var res = new Response<bool>()
            {
                Data = await _service.DeleteAsync(id)
            };
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult<Response<ProductCategoryDto>>> Put([FromBody] ProductCategoryDto dto)
        {
            var response = new Response<ProductCategoryDto>();

            if (!await _service.ProductCategoryExists(dto.Id))
            {
                response.Errors.Add("No existe");
                return NotFound(response);
            }
            response.Data = await _service.UpdateAsync(dto);
            return Ok(response);
        }
    }
}