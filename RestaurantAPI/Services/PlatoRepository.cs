using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class PlatoRepository: IPlato
    {
        private  RestaurantContext _restaurant = new RestaurantContext();

        public Plato edite(int id)
        {
            Plato objEncontrado = _restaurant.Platos.Where(idP => idP.IdPlato == id).Single();
            return objEncontrado;
        }
        public void remove(int id)
        {
            Plato objEncontrado = _restaurant.Platos.Where(idP => idP.IdPlato == id).Single();
            _restaurant.Platos.Remove(objEncontrado);
            _restaurant.SaveChanges();
        }

        public void editeDetails(Plato obj)
        {
            Plato objAModificar = _restaurant.Platos.Where(idP => idP.IdPlato == obj.IdPlato).FirstOrDefault();
            if (objAModificar != null)
            {
                objAModificar.Nombre = obj.Nombre;
                objAModificar.Descripcion = obj.Descripcion;
                objAModificar.Precio = obj.Precio;
                objAModificar.MenuDelDia = obj.MenuDelDia;
            }
            _restaurant.SaveChanges();
        }
        public IEnumerable<Plato> GetAllPlatos()
        {
            return _restaurant.Platos;
        }
        public void add(Plato obj)
        {
            _restaurant.Platos.Add(obj);
            _restaurant.SaveChanges();
        }
        public Plato GetPlatoById(int id)
        {
            return _restaurant.Platos.Where(tpla => tpla.IdPlato == id).FirstOrDefault(); 
        }
    }
}
