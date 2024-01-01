namespace gamer_store_api.Data.DTOs;

public class VentaProductoDtoSet
{
    public int? IdVentaProducto { get; set; }
    public int IdVenta { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
    public bool Activo { get; set; }
    public string UsuarioModificacion { get; set; } = "";
}