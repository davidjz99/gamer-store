using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace gamer_store_api.Services;

public class LoginService
{
    private readonly GamerStoreContext _context;
    private IConfiguration config;

    public LoginService(GamerStoreContext context, IConfiguration config)
    {
        _context = context;
        this.config = config;
    }

    public async Task<Usuario?> GetAuth(UsuarioDtoSet usuario)
    {
        return await _context.Usuarios.
            SingleOrDefaultAsync(x => x.Username == usuario.Username && x.Password == usuario.Password);
    }

    public string GenerarToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Nombres),
            new Claim(ClaimTypes.PostalCode, usuario.CodigoPostal)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds
        );

        string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return token;
    }
}