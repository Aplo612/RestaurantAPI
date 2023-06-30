using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IPedido
    {
        void CrearPedido(Pedido pedido);
        IEnumerable<Pedido> GetAllPedidos(); 
        Pedido GetPedidoById(int id);
        void EditarPedido(Pedido pedido);
    }
}
