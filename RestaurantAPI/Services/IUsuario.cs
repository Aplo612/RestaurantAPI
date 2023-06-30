using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IUsuario
    {
        Task<Usuario> GetUsuario(string user, string contraseña);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
