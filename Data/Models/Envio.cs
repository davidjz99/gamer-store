using System;
using System.Collections.Generic;

namespace gamer_store_api.Data.Models;

public partial class Envio
{
    public int IdEnvio { get; set; }

    public int IdVenta { get; set; }

    public int IdRepartidor { get; set; }

    public bool Entregado { get; set; }

    public DateTime FechaEntregaEstimada { get; set; }

    public DateTime? FechaRecepcion { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public virtual Usuario IdRepartidorNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
