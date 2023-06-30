using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestaurantAPI.Models;

public partial class DetallePedido
{
    public int IdDetallePedido { get; set; }

    public int IdPedido { get; set; }

    public int IdPlato { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }
    [JsonIgnore]
    public virtual Pedido? IdPedidoNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Plato? IdPlatoNavigation { get; set; } = null!;
}
