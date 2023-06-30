using System;
using System.Collections.Generic;

namespace RestaurantAPI.Models;

public partial class Boletum
{
    public int IdBoleta { get; set; }

    public int IdPedido { get; set; }

    public decimal Total { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
