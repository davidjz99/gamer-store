using System;
using System.Collections.Generic;

namespace gamer_store_api.Data.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual ICollection<VentasProducto> VentasProductos { get; set; } = new List<VentasProducto>();
}
