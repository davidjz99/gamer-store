using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;
using gamer_store_api.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace gamer_store_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PlataformasController: ControllerBase
{
    private readonly PlataformasService _service;

    public PlataformasController(PlataformasService service)
    {
        _service = service;
    }

    #region get
    [HttpGet]
    public async Task<IEnumerable<Plataforma>> GetPlataformas()
    {
        return await _service.GetPlataformas();
    }

    [HttpGet("{idPlataforma}")]
    public async Task<ActionResult<Plataforma>> GetPlataformaById(int idPlataforma)
    {
        var plataforma = await _service.GetPlataformaById(idPlataforma);

        if(plataforma is null){
            return PlataformaNoEncontrada(idPlataforma);
        }
        else{
            return plataforma;
        }
    }
    #endregion get

    #region set
    [HttpPost]
    public async Task<IActionResult> InsertPlataforma(PlataformaDtoSet plataforma){        
        var newPlataforma = await _service.InsertPlataforma(plataforma);  

        return CreatedAtAction(nameof(GetPlataformaById), new { idPlataforma = newPlataforma.IdPlataforma }, newPlataforma);
    }
    #endregion set

    #region put
    [HttpPut("{idPlataforma}")]
    public async Task<IActionResult> UpdatePlataforma(int idPlataforma, PlataformaDtoSet plataforma){
        if(idPlataforma != plataforma.IdPlataforma) return BadRequest(new { message = $"No coinciden los ids proporcionados" });

        var plataformaUpdated = await _service.UpdatePlataforma(idPlataforma, plataforma);

        if(plataformaUpdated is not null) return CreatedAtAction(nameof(GetPlataformaById), new { idPlataforma = plataformaUpdated.IdPlataforma }, plataformaUpdated);

        return PlataformaNoEncontrada(idPlataforma);
    }

    [HttpPut("delete/{idPlataforma}")]
    public async Task<IActionResult> DeletePlataforma(int idPlataforma){
        var plataformaDeleted = await _service.DeletePlataforma(idPlataforma);
        if(plataformaDeleted is true) return Ok();

        return PlataformaNoEncontrada(idPlataforma);
    }
    #endregion put

    public NotFoundObjectResult PlataformaNoEncontrada(int idPlataforma){
        return NotFound(new { message = $"No existe la categoria con id = {idPlataforma}." });
    }
}