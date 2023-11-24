namespace gamer_store_api.Data.DTOs;

public class CategoriaDtoSet
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public bool Activo { get; set; } = true;
    public string UsuarioModificacion { get; set; } = "";
    //public DateTime FechaModificacion { get; set; } = DateTime.Now;
}