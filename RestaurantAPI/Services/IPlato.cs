using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IPlato
    {
        IEnumerable<Plato> GetAllPlatos();
        void add(Plato obj);
        void remove(int id);
        Plato edite(int id);
        void editeDetails(Plato obj);
        Plato GetPlatoById(int id);
    }
}
