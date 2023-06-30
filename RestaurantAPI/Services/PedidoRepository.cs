using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class PedidoRepository : IPedido
    {
        private RestaurantContext _restaurant = new RestaurantContext();
        public void CrearPedido(Pedido pedido)
        {
            _restaurant.Pedidos.Add(pedido);
            foreach (var detallePedido in pedido.DetallePedidos)
            {
                _restaurant.DetallePedidos.Add(detallePedido);
            }
            _restaurant.SaveChanges();
        }

        public void EditarPedido(Pedido pedido)
        {
            Pedido objAModificar = _restaurant.Pedidos.Where(idP => idP.IdPedido == pedido.IdPedido).FirstOrDefault();
            if (objAModificar != null)
            {
                objAModificar.Estado = pedido.Estado;
                objAModificar.DetallePedidos = pedido.DetallePedidos;
            }
            _restaurant.SaveChanges();
        }

        public IEnumerable<Pedido> GetAllPedidos()
        {
            return _restaurant.Pedidos.Include(p => p.DetallePedidos);
        }

        public Pedido GetPedidoById(int id)
        {
            return _restaurant.Pedidos.Include(p => p.DetallePedidos)
                        .Where(tpe => tpe.IdPedido == id).FirstOrDefault();
        }
    }
}
