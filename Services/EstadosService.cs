using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_store_api.Services;

public class EstadosService
{
    private readonly GamerStoreContext _context;

    public EstadosService(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    public async Task<IEnumerable<Estado>> GetEstados()
    {
        return await _context.Estados.ToListAsync();
    }

    public async Task<Estado?> GetEstadoById(int idEstado)
    {
        return await _context.Estados.FindAsync(idEstado);
    }
    #endregion get
    
    #region set
    public async Task<Estado> InsertEstado(EstadoDtoSet estadoDTO){
        var estado = new Estado();

        estado.Nombre = estadoDTO.Nombre;
        estado.Activo = estadoDTO.Activo;
        estado.UsuarioCreacion = estadoDTO.UsuarioModificacion;
        estado.FechaCreacion = DateTime.Now;
        estado.UsuarioModificacion = estadoDTO.UsuarioModificacion;
        estado.FechaModificacion = DateTime.Now;

        //estado.FechaCreacion = DateTime.Now;
        //estado.FechaModificacion = DateTime.Now;

        // estado.FechaModificacion = estado.FechaCreacion;
        //estado.UsuarioCreacion = estado.UsuarioModificacion;

        _context.Estados.Add(estado);
        await _context.SaveChangesAsync();

        return estado;
    }
    #endregion set

    #region put
    public async Task<Estado?> UpdateEstado(int idEstado, EstadoDtoSet estado){
        var existeEstado = await GetEstadoById(idEstado);
        if(existeEstado is not null){
            existeEstado.Nombre = estado.Nombre;
            existeEstado.UsuarioModificacion = estado.UsuarioModificacion;
            existeEstado.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return existeEstado;
        }

        return null;
    }

    public async Task<Boolean> DeleteEstado(int idEstado){
        var existeEstado = await GetEstadoById(idEstado);
        if(existeEstado is not null){
            existeEstado.Activo = false;

            await _context.SaveChangesAsync();
            return true;
        }

        return false;  
    }
    #endregion put

    // #region delete
    // public async Task<Boolean> DeleteEstado(int idEstado){        
    //     var existeEstado = GetEstadoById(idEstado);
    //     if(existeEstado is not null){
    //         _context.Estados.Remove(existeEstado);
            
    //         _context.SaveChanges();
    //         return true;
    //     }
    
    //      return false;
    // }
    // #endregion delete
}