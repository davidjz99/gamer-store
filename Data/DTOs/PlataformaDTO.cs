namespace gamer_store_api.Data.DTOs;

public class PlataformaDtoSet
{
    public int? IdPlataforma { get; set; }
    public string Nombre { get; set; } = "";
    public string? Abreviacion { get; set; } = "";
    public bool Activo { get; set; } = true;
    public string UsuarioModificacion { get; set; } = "";
}

public class PlataformaDtoGet
{
    public int IdPlataforma { get; set; }
    public string Nombre { get; set; } = "";
    public string? Abreviacion { get; set; } = "";
    public bool Activo { get; set; } = true;
    public string UsuarioModificacion { get; set; } = "";
}