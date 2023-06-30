using RestaurantAPI.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace RestaurantAPI.Services
{
    public class UsuarioRepository : IUsuario
    {
        private RestaurantContext _context = new RestaurantContext();
        public async Task<Usuario> GetUsuario(string user, string contraseña)
        {
            Usuario usuario_encontrado = await _context.Usuarios.Where(u => u.Email == user && u.Contraseña == contraseña)
                 .FirstOrDefaultAsync();
            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _context.Usuarios.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
    }
}
