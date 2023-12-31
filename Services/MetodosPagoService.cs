using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_store_api.Services;

public class MetodosPagoService
{
    private readonly GamerStoreContext _context;

    public MetodosPagoService(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    public async Task<IEnumerable<MetodoPagoDtoGet>> GetMetodosPago()
    {
        return await  _context.MetodosPagos.
        Where(m => m.Activo == true).
        Select(m => new MetodoPagoDtoGet
        {
            IdMetodoPago = m.IdMetodoPago,
            Nombre = m.Nombre,
            Activo = m.Activo,
            UsuarioModificacion = m.UsuarioModificacion
        }).ToListAsync();
    }

    public async Task<MetodoPagoDtoGet?> GetMetodosPagoById(int idMetodoPago)
    {
        return await _context.MetodosPagos.
        Where(m => m.IdMetodoPago == idMetodoPago && m.Activo == true).
        Select(m => new MetodoPagoDtoGet
        {
            IdMetodoPago = m.IdMetodoPago,
            Nombre = m.Nombre,
            Activo = m.Activo,
            UsuarioModificacion = m.UsuarioModificacion
        }).SingleOrDefaultAsync();
    }
    #endregion get
}