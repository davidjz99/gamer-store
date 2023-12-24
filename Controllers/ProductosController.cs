using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Services;
using gamer_store_api.Data.Models;
using gamer_store_api.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace gamer_store_api.Controllers;

[Authorize]
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
        var producto = await _service.GetProductoDtoById(idProducto);

        if(producto is null){
            return ProductoNoEncontrado(idProducto);
        }
        else{
            return producto;
        }
    }
    #endregion get

    #region set
    [HttpPost]
    public async Task<IActionResult> InsertProducto(ProductoDtoSet producto){        
        var newProducto = await _service.InsertProducto(producto);  

        return CreatedAtAction(nameof(GetProductoById), new { idProducto = newProducto.IdProducto }, newProducto);
    }
    #endregion set

    #region put
    [HttpPut("{idProducto}")]
    public async Task<IActionResult> UpdateProducto(int idProducto, ProductoDtoSet producto){
        if(idProducto != producto.IdProducto) return BadRequest(new { message = $"No coinciden los ids proporcionados" });

        var productoUpdated = await _service.UpdateProducto(idProducto, producto);

        if(productoUpdated is not null) return CreatedAtAction(nameof(GetProductoById), new { idProducto = productoUpdated.IdProducto }, productoUpdated);

        return ProductoNoEncontrado(idProducto);
    }

    [HttpPut("delete/{idProducto}")]
    public async Task<IActionResult> DeleteProducto(int idProducto){
        var productoDeleted = await _service.DeleteProducto(idProducto);
        if(productoDeleted is true) return Ok();

        return ProductoNoEncontrado(idProducto);
    }
    #endregion put

    public NotFoundObjectResult ProductoNoEncontrado(int idProducto){
        return NotFound(new { message = $"No existe el producto con id = {idProducto}." });
    }
}