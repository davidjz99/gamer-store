using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_store_api.Services;

public class UnidadesMedidaService
{
    private readonly GamerStoreContext _context;

    public UnidadesMedidaService(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    public async Task<IEnumerable<UnidadMedidaDtoGet>> GetUnidadesMedida()
    {
        return await  _context.UnidadesMedida.
        Where(u => u.Activo == true).
        Select(u => new UnidadMedidaDtoGet
        {
            IdUnidadMedida = u.IdUnidadMedida,
            Nombre = u.Nombre,
            Abreviacion = u.Abreviacion,
            Activo = u.Activo,
            UsuarioModificacion = u.UsuarioModificacion
        }).ToListAsync();
    }

    public async Task<UnidadMedidaDtoGet?> GetUnidadesMedidaById(int idUnidadMedida)
    {
        return await _context.UnidadesMedida.
        Where(u => u.IdUnidadMedida == idUnidadMedida && u.Activo == true).
        Select(u => new UnidadMedidaDtoGet
        {
            IdUnidadMedida = u.IdUnidadMedida,
            Nombre = u.Nombre,
            Abreviacion = u.Abreviacion,
            Activo = u.Activo,
            UsuarioModificacion = u.UsuarioModificacion
        }).SingleOrDefaultAsync();
    }
    #endregion get
}