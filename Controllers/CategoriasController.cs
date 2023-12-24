using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;
using gamer_store_api.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace gamer_store_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CategoriasController: ControllerBase
{
    private readonly CategoriasService _service;

    public CategoriasController(CategoriasService service)
    {
        _service = service;
    }

    #region get
    [HttpGet]
    public async Task<IEnumerable<Categoria>> GetCategorias()
    {
        return await _service.GetCategorias();
    }

    [HttpGet("{idCategoria}")]
    public async Task<ActionResult<Categoria>> GetCategoriaById(int idCategoria)
    {
        var categoria = await _service.GetCategoriaById(idCategoria);

        if(categoria is null){
            return CategoriaNoEncontrada(idCategoria);
        }
        else{
            return categoria;
        }
    }
    #endregion get

    #region set
    [HttpPost]
    public async Task<IActionResult> InsertCategoria(CategoriaDtoSet categoria){        
        var newCategoria = await _service.InsertCategoria(categoria);  

        return CreatedAtAction(nameof(GetCategoriaById), new { idCategoria = newCategoria.IdCategoria }, newCategoria);
    }
    #endregion set

    #region put
    [HttpPut("{idCategoria}")]
    public async Task<IActionResult> UpdateCategoria(int idCategoria, CategoriaDtoSet categoria){
        if(idCategoria != categoria.IdCategoria) return BadRequest(new { message = $"No coinciden los ids proporcionados" });

        var categoriaUpdated = await _service.UpdateCategoria(idCategoria, categoria);

        if(categoriaUpdated is not null) return CreatedAtAction(nameof(GetCategoriaById), new { idCategoria = categoriaUpdated.IdCategoria }, categoriaUpdated);

        return CategoriaNoEncontrada(idCategoria);
    }

    [HttpPut("delete/{idCategoria}")]
    public async Task<IActionResult> DeleteCategoria(int idCategoria){
        var categoriaDeleted = await _service.DeleteCategoria(idCategoria);
        if(categoriaDeleted is true) return Ok();

        return CategoriaNoEncontrada(idCategoria);
    }
    #endregion put

    public NotFoundObjectResult CategoriaNoEncontrada(int idCategoria){
        return NotFound(new { message = $"No existe la categoria con id = {idCategoria}." });
    }
}