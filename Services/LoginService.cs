using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_store_api.Services;

public class LoginService
{
    private readonly GamerStoreContext _context;

    public LoginService(GamerStoreContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetAuth(UsuarioDtoSet usuario)
    {
        return await _context.Usuarios.
            SingleOrDefaultAsync(x => x.Username == usuario.Username && x.Password == usuario.Password);
    }
}