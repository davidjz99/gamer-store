using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_store_api.Services;

public class UsuariosService
{
    private readonly GamerStoreContext _context;

    public UsuariosService(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    public async Task<IEnumerable<UsuarioDtoGet>> GetUsuarios()
    {
        return await _context.Usuarios.
        Where(u => u.Activo == true).
        Select(u => new UsuarioDtoGet
        {
            IdUsuario = u.IdUsuario,
            Username = u.Username,
            Password = u.Password,
            Rol = u.IdRolNavigation.Nombre,
            Estado = u.IdEstadoNavigation.Nombre,
            Nombres = u.Nombres,
            ApellidoPaterno = u.ApellidoPaterno,
            ApellidoMaterno = u.ApellidoMaterno,
            NumeroTelefonico = u.NumeroTelefonico,
            Calle = u.Calle,
            NumeroExterior = u.NumeroExterior,
            NumeroInterior = u.NumeroInterior,
            Colonia = u.Colonia,
            CodigoPostal = u.CodigoPostal,
            Activo = u.Activo,
            UsuarioModificacion = u.UsuarioModificacion
        }).ToListAsync();
    }

    public async Task<UsuarioDtoGet?> GetUsuarioDtoById(int idUsuario)
    {
        return await _context.Usuarios.
        Where(u => u.IdUsuario == idUsuario && u.Activo == true).
        Select(u => new UsuarioDtoGet
        {
            IdUsuario = u.IdUsuario,
            Username = u.Username,
            Password = u.Password,
            Rol = u.IdRolNavigation.Nombre,
            Estado = u.IdEstadoNavigation.Nombre,
            Nombres = u.Nombres,
            ApellidoPaterno = u.ApellidoPaterno,
            ApellidoMaterno = u.ApellidoMaterno,
            NumeroTelefonico = u.NumeroTelefonico,
            Calle = u.Calle,
            NumeroExterior = u.NumeroExterior,
            NumeroInterior = u.NumeroInterior,
            Colonia = u.Colonia,
            CodigoPostal = u.CodigoPostal,
            Activo = u.Activo,
            UsuarioModificacion = u.UsuarioModificacion
        }).SingleOrDefaultAsync();
    }

    public async Task<Usuario?> GetUsuarioById(int idUsuario)
    {
        return await _context.Usuarios.FindAsync(idUsuario);
    }
    #endregion get

    #region set
    public async Task<Usuario> InsertUsuario(UsuarioDtoSet usuarioDTO){
        var usuario = new Usuario();

        usuario.IdRol = usuarioDTO.IdRol;
        usuario.IdEstado = usuarioDTO.IdEstado;
        usuario.Nombres = usuarioDTO.Nombres;
        usuario.ApellidoPaterno = usuarioDTO.ApellidoPaterno;
        usuario.ApellidoMaterno = usuarioDTO.ApellidoMaterno;
        usuario.NumeroTelefonico = usuarioDTO.NumeroTelefonico;
        usuario.Calle = usuarioDTO.Calle;
        usuario.NumeroExterior = usuarioDTO.NumeroExterior;
        usuario.NumeroInterior = usuarioDTO.NumeroInterior;
        usuario.Colonia = usuarioDTO.Colonia;
        usuario.CodigoPostal = usuarioDTO.CodigoPostal;
        usuario.Activo = usuarioDTO.Activo;
        usuario.UsuarioCreacion = usuarioDTO.UsuarioModificacion;
        usuario.FechaCreacion = DateTime.Now;
        usuario.UsuarioModificacion = usuarioDTO.UsuarioModificacion;
        usuario.FechaModificacion = DateTime.Now;

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }
    #endregion set

    #region put
    public async Task<Usuario?> UpdateUsuario(int idUsuario, UsuarioDtoSet usuario){
        var existeUsuario = await GetUsuarioById(idUsuario);
        if(existeUsuario is not null){
            existeUsuario.IdRol = usuario.IdRol;
            existeUsuario.IdEstado = usuario.IdEstado;
            existeUsuario.Nombres = usuario.Nombres;
            existeUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
            existeUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
            existeUsuario.NumeroTelefonico = usuario.NumeroTelefonico;
            existeUsuario.Calle = usuario.Calle;
            existeUsuario.NumeroExterior = usuario.NumeroExterior;
            existeUsuario.NumeroInterior = usuario.NumeroInterior;
            existeUsuario.Colonia = usuario.Colonia;
            existeUsuario.CodigoPostal = usuario.CodigoPostal;
            existeUsuario.UsuarioModificacion = usuario.UsuarioModificacion;
            existeUsuario.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return existeUsuario;
        }

        return null;
    }

    public async Task<Boolean> DeleteUsuario(int idUsuario){
        var existeUsuario = await GetUsuarioById(idUsuario);
        if(existeUsuario is not null){
            existeUsuario.Activo = false;

            await _context.SaveChangesAsync();
            return true;
        }

        return false;  
    }
    #endregion put
}