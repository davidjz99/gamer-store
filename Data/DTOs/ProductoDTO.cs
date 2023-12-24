namespace gamer_store_api.Data.DTOs;

public class ProductoDtoSet
{
    public int? IdProducto { get; set; }
    public int IdCategoria { get; set; }
    public int? IdPlataforma { get; set; }
    public int IdUnidadMedida { get; set; }
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public decimal Peso { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public bool Activo { get; set; } = true;
    public string UsuarioModificacion { get; set; } = "";
}

public class ProductoDtoGet
{
    public int IdProducto { get; set; }
    public int IdCategoria { get; set; }
    public string Categoria { get; set; } = "";
    public int? IdPlataforma { get; set; }
    public string? Plataforma { get; set; }
    public int IdUnidadMedida { get; set; }
    public string UnidadMedida { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public decimal Peso { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public bool Activo { get; set; } = true;
    public string UsuarioModificacion { get; set; } = "";
}