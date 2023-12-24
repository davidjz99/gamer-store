using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;
using gamer_store_api.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace gamer_store_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductosController: ControllerBase
{
    private readonly ProductosService _service;

    public ProductosController(ProductosService service)
    {
        _service = service;
    }

    #region get
    [HttpGet]
    public async Task<IEnumerable<ProductoDtoGet>> GetProductos()
    {
        return await _service.GetProductos();
    }

    [HttpGet("{idProducto}")]
    public async Task<ActionResult<ProductoDtoGet>> GetProductoById(int idProducto)
    {
        var producto = await _service.GetProductoById(idProducto);

        if(producto is null){
            return ProductoNoEncontrado(idProducto);
        }
        else{
            return producto;
        }
    }
    #endregion get

    public NotFoundObjectResult ProductoNoEncontrado(int idProducto){
        return NotFound(new { message = $"No existe el producto con id = {idProducto}." });
    }
}