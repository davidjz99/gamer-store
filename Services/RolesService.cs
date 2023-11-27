using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_store_api.Services;

public class RolesService
{
    private readonly GamerStoreContext _context;

    public RolesService(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    public async Task<IEnumerable<Rol>> GetRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Rol?> GetRolById(int idRol)
    {
        return await _context.Roles.FindAsync(idRol);
    }
    #endregion get

    #region set
    public async Task<Rol> InsertRol(RolDtoSet rolDTO){
        var rol = new Rol();

        rol.Nombre = rolDTO.Nombre;
        rol.Descripcion = rolDTO.Descripcion;
        rol.Activo = rolDTO.Activo;
        rol.UsuarioCreacion = rolDTO.UsuarioModificacion;
        rol.FechaCreacion = DateTime.Now;
        rol.UsuarioModificacion = rolDTO.UsuarioModificacion;
        rol.FechaModificacion = DateTime.Now;

        _context.Roles.Add(rol);
        await _context.SaveChangesAsync();

        return rol;
    }
    #endregion set

    #region put
    public async Task<Rol?> UpdateRol(int idRol, RolDtoSet rol){
        var existeRol = await GetRolById(idRol);
        if(existeRol is not null){
            existeRol.Nombre = rol.Nombre;
            existeRol.Descripcion = rol.Descripcion;
            existeRol.UsuarioModificacion = rol.UsuarioModificacion;
            existeRol.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return existeRol;
        }

        return null;
    }

    public async Task<Boolean> DeleteRol(int idRol){
        var existeRol = await GetRolById(idRol);
        if(existeRol is not null){
            existeRol.Activo = false;

            await _context.SaveChangesAsync();
            return true;
        }

        return false;  
    }
    #endregion put
}