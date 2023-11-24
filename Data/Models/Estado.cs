using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamer_store_api.Data.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    [MaxLength(150, ErrorMessage = "El nombre del estado no puede exceder los 150 caracteres.")]
    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    [MaxLength(150)]
    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    [MaxLength(150)]
    public string UsuarioModificacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
