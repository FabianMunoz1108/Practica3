using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : Controller
    {

        private IBrandRepository _repository;

        public BrandController(IBrandRepository repository)
        {
            _repository = repository;
        }
        #region Métodos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<List<BrandDto>>>> GetBrands()
        {
            var res = new Response<List<BrandDto>>();
            var lista = await _repository.GetAllAsync();

            if (lista.Any())
            {
                res.Data = lista.Select(b => new BrandDto(b)).ToList();
                return Ok(res);
            }
            return NotFound(res);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<BrandDto>>> GetBrand(int id)
        {
            var res = new Response<BrandDto>();
            var brand = await _repository.GetByIdAsync(id);

            if (brand != null)
            {
                BrandDto dto = new(brand);
                res.Data = dto;
                return Ok(res);
            }
            return NotFound(res);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Response<BrandDto>>> PostBrand([FromBody] BrandDto dto)
        {
            var res = new Response<BrandDto>();
            Brand marca = new()
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedDate = DateTime.Now,
                CreatedBy = Login,
            };
            marca = await _repository.SaveAsync(marca);
            dto.Id = marca.Id;
            res.Data = dto;

            return CreatedAtAction("GetBrand", new { Id = 0 }, res);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Response<BrandDto>>> PutBrand([FromBody] BrandDto dto)
        {
            var res = new Response<BrandDto>();
            Brand marca = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                UpdatedDate = DateTime.Now,
                UpdatedBy = Login,
            };
            marca = await _repository.UpdateAsync(marca);
            /*Si dentro del método se cambió el Id a 0, es para indicar que el registro no existe o ya está eliminado*/
            if (marca.Id == 0)
            {
                res.Data = dto;
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response<bool>>> DeleteBrand(int id)
        {
            var res = new Response<bool>();
            res.Data = await _repository.DeleteAsync(id);

            if (res.Data)
            {
                return Ok(res);
            }
            return NotFound(res);
        }

        public string Login { get; set; } = "";
        #endregion
    }
}