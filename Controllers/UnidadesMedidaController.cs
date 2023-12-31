using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;
using gamer_store_api.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace gamer_store_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UnidadesMedidaController: ControllerBase
{
    private readonly UnidadesMedidaService _service;

    public UnidadesMedidaController(UnidadesMedidaService service)
    {
        _service = service;
    }

    #region get
    [HttpGet]
    public async Task<IEnumerable<UnidadMedidaDtoGet>> GetUnidadesMedida()
    {
        return await _service.GetUnidadesMedida();
    }

    [HttpGet("{idMetodoPago}")]
    public async Task<ActionResult<UnidadMedidaDtoGet>> GetUnidadesMedidaById(int idUnidadMedida)
    {
        var unidadMedida = await _service.GetUnidadesMedidaById(idUnidadMedida);

        if(unidadMedida is null){
            return UnidadMedidaNoEncontrada(idUnidadMedida);
        }
        else{
            return unidadMedida;
        }
    }
    #endregion get

    public NotFoundObjectResult UnidadMedidaNoEncontrada(int idUnidadMedida){
        return NotFound(new { message = $"No existe la unidad de medida con id = {idUnidadMedida}." });
    }
}