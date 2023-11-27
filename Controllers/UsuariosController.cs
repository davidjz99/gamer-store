using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;
using gamer_store_api.Data.DTOs;

namespace gamer_store_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuariosController: ControllerBase
{
    private readonly UsuariosService _service;

    public UsuariosController(UsuariosService service)
    {
        _service = service;
    }

    #region get
    [HttpGet]
    public async Task<IEnumerable<UsuarioDtoGet>> GetUsuarios()
    {
        return await _service.GetUsuarios();
    }

    [HttpGet("{idUsuario}")]
    public async Task<ActionResult<UsuarioDtoGet>> GetUsuarioById(int idUsuario)
    {
        var usuario = await _service.GetUsuarioDtoById(idUsuario);

        if(usuario is null){
            return UsuarioNoEncontrado(idUsuario);
        }
        else{
            return usuario;
        }
    }
    #endregion get

    #region set
    [HttpPost]
    public async Task<IActionResult> InsertUsuario(UsuarioDtoSet usuario){        
        var newUsuario = await _service.InsertUsuario(usuario);  

        return CreatedAtAction(nameof(GetUsuarioById), new { idUsuario = newUsuario.IdUsuario }, newUsuario);
    }
    #endregion set

    #region put
    [HttpPut("{idUsuario}")]
    public async Task<IActionResult> UpdateUsuario(int idUsuario, UsuarioDtoSet usuario){
        if(idUsuario != usuario.IdUsuario) return BadRequest(new { message = $"No coinciden los ids proporcionados" });

        var usuarioUpdated = await _service.UpdateUsuario(idUsuario, usuario);

        if(usuarioUpdated is not null) return CreatedAtAction(nameof(GetUsuarioById), new { idUsuario = usuarioUpdated.IdUsuario }, usuarioUpdated);

        return UsuarioNoEncontrado(idUsuario);
    }

    [HttpPut("delete/{idUsuario}")]
    public async Task<IActionResult> DeleteUsuario(int idUsuario){
        var usuarioDeleted = await _service.DeleteUsuario(idUsuario);
        if(usuarioDeleted is true) return Ok();

        return UsuarioNoEncontrado(idUsuario);
    }
    #endregion put

    public NotFoundObjectResult UsuarioNoEncontrado(int idUsuario){
        return NotFound(new { message = $"No existe el usuario con id = {idUsuario}." });
    }
}