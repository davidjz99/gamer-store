public class UnidadMedidaDtoGet
{
    public int IdUnidadMedida { get; set; }
    public string Nombre { get; set; } = "";
    public string? Abreviacion { get; set; } = "";
    public bool Activo { get; set; } = true;
    public string UsuarioModificacion { get; set; } = "";
}