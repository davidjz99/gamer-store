namespace gamer_store_api.Data.DTOs;

public class RolDtoSet
{
    public int IdRol { get; set; }
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public bool Activo { get; set; } = true;
    public string UsuarioModificacion { get; set; } = "";
}