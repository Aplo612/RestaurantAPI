using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Security.Claims;
using RestaurantAPI.Recursos;

namespace RestaurantAPI.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        public readonly IUsuario _usuarios;
        public UsuariosController(IUsuario usuarios)
        {
            _usuarios = usuarios;
        }
        [HttpPost("Registrarse")]
        public async Task<IActionResult> Registrarse([FromBody] Usuario modelo)
        {
            modelo.Contraseña = Utilidades.EncriptarClave(modelo.Contraseña);

            Usuario usuario_creado = await _usuarios.SaveUsuario(modelo);

            if (usuario_creado.IdUsuario > 0)
                return Ok(usuario_creado);

            return BadRequest("No se pudo crear el usuario");
        }
        [HttpPost("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] Usuario credenciales)
        {
            Usuario usuario_encontrado = await _usuarios.GetUsuario(credenciales.Email, Utilidades.EncriptarClave(credenciales.Contraseña));

            if (usuario_encontrado == null)
            {
                return NotFound("No se encontraron coincidencias");
            }

            return Ok(usuario_encontrado);
        }
    }
}