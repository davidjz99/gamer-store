using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;
using gamer_store_api.Data.DTOs;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace gamer_store_api.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController: ControllerBase
{
    private readonly LoginService _service;

    public LoginController(LoginService service)
    {
        _service = service;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Login(UsuarioDtoSet usuario)
    {
        var user = await _service.GetAuth(usuario);

        if(user is null)
        {
            return BadRequest(new { message = "Credenciales invalidas" });
        } 

        //token
        return Ok(new { token = "token value" });
    }
}