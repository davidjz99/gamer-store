using System;
using System.Collections.Generic;

namespace gamer_store_api.Data.Models;

public partial class VentasProducto
{
    public int IdVentaProducto { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
