using System;
using System.Collections.Generic;

namespace gamer_store_api.Data.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
