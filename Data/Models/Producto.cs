using System;
using System.Collections.Generic;

namespace gamer_store_api.Data.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int IdCategoria { get; set; }

    public int? IdPlataforma { get; set; }

    public int IdUnidadMedida { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Peso { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Plataforma? IdPlataformaNavigation { get; set; }

    public virtual UnidadesMedidum IdUnidadMedidaNavigation { get; set; } = null!;

    public virtual ICollection<VentasProducto> VentasProductos { get; set; } = new List<VentasProducto>();
}
