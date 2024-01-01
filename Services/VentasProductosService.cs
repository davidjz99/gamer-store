using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_store_api.Services;

public class VentasProductosService
{
    private readonly GamerStoreContext _context;

    public VentasProductosService(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    public async Task<IEnumerable<VentasProducto>> GetVentasProductos()
    {
        return await _context.VentasProductos.ToListAsync();
    }

    public async Task<VentasProducto?> GetVentaProductoById(int idVentaProducto)
    {
        return await _context.VentasProductos.FindAsync(idVentaProducto);
    }
    #endregion get

    #region set
    public async Task<VentasProducto> InsertVentaProducto(VentaProductoDtoSet ventaProductoDTO){
        var venta = new VentasProducto();

        venta.IdVenta = ventaProductoDTO.IdVenta;
        venta.IdProducto = ventaProductoDTO.IdProducto;
        venta.Cantidad = ventaProductoDTO.Cantidad;
        venta.Activo = ventaProductoDTO.Activo;
        venta.UsuarioCreacion = ventaProductoDTO.UsuarioModificacion;
        venta.FechaCreacion = DateTime.Now;
        venta.UsuarioModificacion = ventaProductoDTO.UsuarioModificacion;
        venta.FechaModificacion = DateTime.Now;

        _context.VentasProductos.Add(venta);
        await _context.SaveChangesAsync();

        return venta;
    }
    #endregion set

    #region put
    public async Task<VentasProducto?> UpdateVentaProducto(int idVentaProducto, VentaProductoDtoSet ventaProductoDTO){
        var existeVP = await GetVentaProductoById(idVentaProducto);
        if(existeVP is not null){
            existeVP.IdVenta = ventaProductoDTO.IdVenta;
            existeVP.IdProducto = ventaProductoDTO.IdProducto;
            existeVP.Cantidad = ventaProductoDTO.Cantidad;
            existeVP.Activo = ventaProductoDTO.Activo;
            existeVP.UsuarioModificacion = ventaProductoDTO.UsuarioModificacion;
            existeVP.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return existeVP;
        }

        return null;
    }

    public async Task<Boolean> DeleteVentaProducto(int idVentaProducto){
        var existeVP = await GetVentaProductoById(idVentaProducto);
        if(existeVP is not null){
            existeVP.Activo = false;

            await _context.SaveChangesAsync();
            return true;
        }

        return false;  
    }
    #endregion put
}