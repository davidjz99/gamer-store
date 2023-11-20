using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;

namespace gamer_store_api.Controllers;

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
        Console.WriteLine("entra???");
        var estado = await _service.GetEstadoById(idEstado);

        if(estado is null){
            return NotFound();
        }
        else{
            return estado;
        }
    }
    #endregion get

    #region set
    [HttpPost]
    public async Task<IActionResult> InsertEstado(Estado estado){        
        var newEstado = await _service.InsertEstado(estado);  

        return CreatedAtAction(nameof(GetEstadoById), new { idEstado = newEstado.IdEstado }, newEstado);
    }
    #endregion set

    #region put
    [HttpPut("{idEstado}")]
    public async Task<IActionResult> UpdateEstado(int idEstado, Estado estado){
        if(idEstado != estado.IdEstado) return BadRequest();

        var estadoUpdated = await _service.UpdateEstado(idEstado, estado);

        if(estadoUpdated is not null) return CreatedAtAction(nameof(GetEstadoById), new { idEstado = estadoUpdated.IdEstado }, estadoUpdated);

        return NotFound();
    }

    [HttpPut("delete/{idEstado}")]
    public async Task<IActionResult> DeleteEstado(int idEstado){
        var estadoDeleted = await _service.DeleteEstado(idEstado);
        if(estadoDeleted is true) return Ok();

        return NotFound();
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
}