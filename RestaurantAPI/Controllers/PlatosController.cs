using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class PlatosController : Controller
    {
        private readonly IPlato _platos;
        public PlatosController(IPlato platos)
        {
            _platos = platos;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var platos = _platos.GetAllPlatos();
            return Ok(platos);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyID(int id)
        {
            var obj = _platos.GetPlatoById(id);
            if (obj == null)
            {
                var error = NotFound("El producto con codigo( " + id.ToString() + ") no existe");
                return error;
            }
            return Ok(obj);
        }
        [HttpPost("agregar")]
        public IActionResult Adicionar(Plato pla)
        {
            _platos.add(pla);
            return CreatedAtAction(nameof(Adicionar), pla);
        }
        [HttpDelete("eliminar/{id}")]
        public IActionResult eliminar(int id)
        {
            _platos.remove(id);
            return NoContent();
        }
        [HttpPut("modificar")]
        public IActionResult editarDetalles(Plato obj)
        {
            _platos.editeDetails(obj);
            return CreatedAtAction(nameof(editarDetalles), obj);
        }
    }
}
