using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;
using gamer_store_api.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace gamer_store_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]

public class VentasProductosController: ControllerBase
{
    private readonly VentasProductosService _service;

    public VentasProductosController(VentasProductosService service)
    {
        _service = service;
    }

    #region get
    [HttpGet]
    public async Task<IEnumerable<VentasProducto>> GetVentasProductos()
    {
        return await _service.GetVentasProductos();
    }

    [HttpGet("{idVentaProducto}")]
    public async Task<ActionResult<VentasProducto>> GetVentaProductoById(int idVentaProducto)
    {
        var ventaProducto = await _service.GetVentaProductoById(idVentaProducto);

        if(ventaProducto is null){
            return VentaProductoNoEncontrada(idVentaProducto);
        }
        else{
            return ventaProducto;
        }
    }
    #endregion get

    #region set
    [HttpPost]
    public async Task<IActionResult> InsertVentaProducto(VentaProductoDtoSet ventaProducto){        
        var newVenta = await _service.InsertVentaProducto(ventaProducto);  

        return CreatedAtAction(nameof(GetVentaProductoById), new { idVentaProducto = newVenta.IdVentaProducto }, newVenta);
    }
    #endregion set

    #region put
    [HttpPut("{idVentaProducto}")]
    public async Task<IActionResult> UpdateVentaProducto(int idVentaProducto, VentaProductoDtoSet ventaProducto){
        if(idVentaProducto != ventaProducto.IdVentaProducto) return BadRequest(new { message = $"No coinciden los ids proporcionados" });

        var ventaProductoUpdated = await _service.UpdateVentaProducto(idVentaProducto, ventaProducto);

        if(ventaProductoUpdated is not null) return CreatedAtAction(nameof(GetVentaProductoById), new { idVentaProducto = ventaProductoUpdated.IdVentaProducto }, ventaProductoUpdated);

        return VentaProductoNoEncontrada(idVentaProducto);
    }

    [HttpPut("delete/{idVentaProducto}")]
    public async Task<IActionResult> DeleteVentaProducto(int idVentaProducto){
        var ventaProductoDeleted = await _service.DeleteVentaProducto(idVentaProducto);
        if(ventaProductoDeleted is true) return Ok();

        return VentaProductoNoEncontrada(idVentaProducto);
    }
    #endregion put

    public NotFoundObjectResult VentaProductoNoEncontrada(int idVentaProducto){
        return NotFound(new { message = $"No existe la venta del producto con id = {idVentaProducto}." });
    }
}