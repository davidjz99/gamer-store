namespace gamer_store_api.Data.DTOs;

public class UsuarioDtoSet
{
    public int? IdUsuario { get; set; }
    public int IdRol { get; set; }
    public int IdEstado { get; set; }
    public string Nombres { get; set; } = "";
    public string ApellidoPaterno { get; set; } = "";
    public string ApellidoMaterno { get; set; } = "";
    public string NumeroTelefonico { get; set; } = "";
    public string Calle { get; set; } = "";
    public string NumeroExterior { get; set; } = "";
    public string? NumeroInterior { get; set; } = "";
    public string Colonia { get; set; } = "";
    public string CodigoPostal { get; set; } = "";
    public bool Activo { get; set; } = true;
    public string UsuarioModificacion { get; set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}

public class UsuarioDtoGet
{
    public int IdUsuario { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Rol { get; set; } = "";
    public string Estado { get; set; } = "";
    public string Nombres { get; set; } = "";
    public string ApellidoPaterno { get; set; } = "";
    public string ApellidoMaterno { get; set; } = "";
    public string NumeroTelefonico { get; set; } = "";
    public string Calle { get; set; } = "";
    public string NumeroExterior { get; set; } = "";
    public string? NumeroInterior { get; set; } = "";
    public string Colonia { get; set; } = "";
    public string CodigoPostal { get; set; } = "";
    public bool Activo { get; set; } = true;
    public string UsuarioModificacion { get; set; } = "";
}