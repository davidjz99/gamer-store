using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;
using gamer_store_api.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace gamer_store_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class EstadosController: ControllerBase
{
    private readonly EstadosService _service;
    public EstadosController(EstadosService service)
    {
        _service = service;
    }

    #region get
    [HttpGet]
    public async Task<IEnumerable<Estado>> GetEstados()
    {
        return await _service.GetEstados();
    }

    [HttpGet("{idEstado}")]
    public async Task<ActionResult<Estado>> GetEstadoById(int idEstado)
    {
        var estado = await _service.GetEstadoById(idEstado);

        if(estado is null){
            return EstadoNoEncontrado(idEstado);
        }
        else{
            return estado;
        }
    }
    #endregion get

    #region set
    [HttpPost]
    public async Task<IActionResult> InsertEstado(EstadoDtoSet estado){        
        var newEstado = await _service.InsertEstado(estado);  

        return CreatedAtAction(nameof(GetEstadoById), new { idEstado = newEstado.IdEstado }, newEstado);
    }
    #endregion set

    #region put
    [HttpPut("{idEstado}")]
    public async Task<IActionResult> UpdateEstado(int idEstado, EstadoDtoSet estado){
        if(idEstado != estado.IdEstado) return BadRequest(new { message = $"No coinciden los ids proporcionados" });

        var estadoUpdated = await _service.UpdateEstado(idEstado, estado);

        if(estadoUpdated is not null) return CreatedAtAction(nameof(GetEstadoById), new { idEstado = estadoUpdated.IdEstado }, estadoUpdated);

        return EstadoNoEncontrado(idEstado);
    }

    [HttpPut("delete/{idEstado}")]
    public async Task<IActionResult> DeleteEstado(int idEstado){
        var estadoDeleted = await _service.DeleteEstado(idEstado);
        if(estadoDeleted is true) return Ok();

        return EstadoNoEncontrado(idEstado);
    }
    #endregion put

    // #region delete
    // [HttpDelete("{idEstado}")]
    // public async Task<IActionResult> DeleteEstado(int idEstado){        
    //     var estadoDeleted = await _service.DeleteEstado(idEstado);
    //     if(estadoDeleted is true) return Ok();

    //     return NotFound();
    // }
    // #endregion delete

    public NotFoundObjectResult EstadoNoEncontrado(int idEstado){
        return NotFound(new { message = $"No existe el estado con id = {idEstado}." });
    }
}