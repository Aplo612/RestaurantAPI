using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly IPedido _pedidos;
        public PedidosController(IPedido pedidos)
        {
            _pedidos = pedidos;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = _pedidos.GetAllPedidos();
            return Ok(pedidos);
        }
        [HttpGet("{id}")]
        public IActionResult GetbyID(int id)
        {
            var obj = _pedidos.GetPedidoById(id);
            if (obj == null)
            {
                var error = NotFound("El producto con codigo( " + id.ToString() + ") no existe");
                return error;
            }
            return Ok(obj);
        }
        [HttpPost("agregar")]
        public IActionResult Adicionar(Pedido obj)
        {
            
            _pedidos.CrearPedido(obj);
            return CreatedAtAction(nameof(Adicionar), obj);
        }
        [HttpPut("modificar")]
        public IActionResult editarDetalles(Pedido obj)
        {
            
            _pedidos.EditarPedido(obj);
            return CreatedAtAction(nameof(editarDetalles), obj);
        }
    }
}
