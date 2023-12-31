using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;
using gamer_store_api.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace gamer_store_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class MetodosPagoController: ControllerBase
{
    private readonly MetodosPagoService _service;

    public MetodosPagoController(MetodosPagoService service)
    {
        _service = service;
    }

    #region get
    [HttpGet]
    public async Task<IEnumerable<MetodoPagoDtoGet>> GetMetodosPago()
    {
        return await _service.GetMetodosPago();
    }

    [HttpGet("{idMetodoPago}")]
    public async Task<ActionResult<MetodoPagoDtoGet>> GetMetodosPagoById(int idMetodoPago)
    {
        var metodoPago = await _service.GetMetodosPagoById(idMetodoPago);

        if(metodoPago is null){
            return MetodoPagoNoEncontrado(idMetodoPago);
        }
        else{
            return metodoPago;
        }
    }
    #endregion get

    public NotFoundObjectResult MetodoPagoNoEncontrado(int idMetodoPago){
        return NotFound(new { message = $"No existe el método de pago con id = {idMetodoPago}." });
    }
}