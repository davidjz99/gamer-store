using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_store_api.Services;

public class PlataformasService
{
    private readonly GamerStoreContext _context;

    public PlataformasService(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    public async Task<IEnumerable<PlataformaDtoGet>> GetPlataformas()
    {
        return await  _context.Plataformas.
        Where(p => p.Activo == true).
        Select(p => new PlataformaDtoGet
        {
            IdPlataforma = p.IdPlataforma,
            Nombre = p.Nombre,
            Abreviacion = p.Abreviacion,
            Activo = p.Activo,
            UsuarioModificacion = p.UsuarioModificacion
        }).ToListAsync();
    }

    public async Task<PlataformaDtoGet?> GetPlataformaDtoById(int idPlataforma)
    {
        return await _context.Plataformas.
        Where(p => p.IdPlataforma == idPlataforma && p.Activo == true).
        Select(p => new PlataformaDtoGet
        {
            IdPlataforma = p.IdPlataforma,
            Nombre = p.Nombre,
            Abreviacion = p.Abreviacion,
            Activo = p.Activo,
            UsuarioModificacion = p.UsuarioModificacion
        }).SingleOrDefaultAsync();
    }

    public async Task<Plataforma?> GetPlataformaById(int idPlataforma)
    {
        return await _context.Plataformas.FindAsync(idPlataforma);
    }
    #endregion get

    #region set
    public async Task<Plataforma> InsertPlataforma(PlataformaDtoSet plataformaDTO){
        var plataforma = new Plataforma();

        plataforma.Nombre = plataformaDTO.Nombre;
        plataforma.Abreviacion = plataformaDTO.Abreviacion;
        plataforma.Activo = plataformaDTO.Activo;
        plataforma.UsuarioCreacion = plataformaDTO.UsuarioModificacion;
        plataforma.FechaCreacion = DateTime.Now;
        plataforma.UsuarioModificacion = plataformaDTO.UsuarioModificacion;
        plataforma.FechaModificacion = DateTime.Now;

        _context.Plataformas.Add(plataforma);
        await _context.SaveChangesAsync();

        return plataforma;
    }
    #endregion set

    #region put
    public async Task<Plataforma?> UpdatePlataforma(int idPlataforma, PlataformaDtoSet plataforma){
        var existePlataforma = await GetPlataformaById(idPlataforma);
        if(existePlataforma is not null){
            existePlataforma.Nombre = plataforma.Nombre;
            existePlataforma.Abreviacion = plataforma.Abreviacion;
            existePlataforma.UsuarioModificacion = plataforma.UsuarioModificacion;
            existePlataforma.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return existePlataforma;
        }

        return null;
    }

    public async Task<Boolean> DeletePlataforma(int idPlataforma){
        var existePlataforma = await GetPlataformaById(idPlataforma);
        if(existePlataforma is not null){
            existePlataforma.Activo = false;

            await _context.SaveChangesAsync();
            return true;
        }

        return false;  
    }
    #endregion put
}