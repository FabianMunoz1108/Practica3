using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeLaSalle.Ecommerce.Api.Controllers
{
    /// <summary>
    /// Proporciona los métodos para la gestión de marcas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
        #region Globales
        private IBrandService _service;
        private readonly IHttpContextAccessor _contextAccessor;
        #endregion

        #region Constructores
        public BrandController(IBrandService service, IHttpContextAccessor contextAccessor)
        {
            _service = service;
            _contextAccessor = contextAccessor;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Recupera el listado de marcas que no están eliminadas
        /// </summary>
        /// <returns>Lista de marcas</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Response<List<BrandDto>>>> GetBrands()
        {
            var res = new Response<List<BrandDto>>();
            var lista = await _service.GetAllAsync();

            if (lista != null)
            {
                res.Data = lista;
                return Ok(res);
            }
            return NotFound(res);
        }
        /// <summary>
        /// Recupera el detalle de la marca especificada
        /// </summary>
        /// <param name="id">Identificador de marca</param>
        /// <returns>Datos de la marca</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Response<BrandDto>>> GetBrand(int id)
        {
            var res = new Response<BrandDto>();
            var brand = await _service.GetByIdAsync(id);

            if (brand != null)
            {
                res.Data = brand;
                return Ok(res);
            }
            res.Errors.Add("Marca no encontrada!");
            return NotFound(res);
        }
        /// <summary>
        /// Guarda un nuevo registro de marca
        /// </summary>
        /// <param name="dto">Datos de la nueva marca</param>
        /// <returns>Datos de la marca creada</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Response<BrandDto>>> PostBrand([FromBody] BrandDto dto)
        {
            var res = new Response<BrandDto>();
            dto = await _service.SaveAsync(dto);
            res.Data = dto;

            return CreatedAtAction("GetBrand", new { Id = 0 }, res);
        }
        /// <summary>
        /// Actualiza los datos de la marca
        /// </summary>
        /// <param name="dto">Datos a actualizar</param>
        /// <returns>Respuesta vacía en caso de actualización exitosa</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Response<BrandDto>>> PutBrand([FromBody] BrandDto dto)
        {
            var res = new Response<BrandDto>();
            dto = await _service.UpdateAsync(dto);
            /*Si dentro del método se cambió el Id a 0, es para indicar que el registro no existe o ya está eliminado*/
            if (dto.Id == 0)
            {
                res.Data = dto;
                return NotFound();
            }
            return NoContent();
        }
        /// <summary>
        /// Realiza borrado lógico de la marca solicitada
        /// </summary>
        /// <param name="id">Identificador de la marca a eliminar</param>
        /// <returns>Valor booleano que indica si se realizó el cambio de estatus correctamente</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Response<bool>>> DeleteBrand(int id)
        {
            var res = new Response<bool>
            {
                Data = await _service.DeleteAsync(id)
            };
            if (res.Data)
            {
                return Ok(res);
            }
            return NotFound(res);
        }
        #endregion

        #region Propiedades
        public string Login
        {
            get
            {
                /*Obtención de Id de usuario en sesión*/
                Claim? claim = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
                return claim?.Value;
            }
        }
        #endregion
    }
}