using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_store_api.Services;

public class ProductosService
{
    private readonly GamerStoreContext _context;

    public ProductosService(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    public async Task<IEnumerable<ProductoDtoGet>> GetProductos()
    {
        // Se hace un query para incluir "lefts joins"
        var query = _context.Productos
            .Join(_context.Categorias,
                producto => producto.IdCategoria,
                categoria => categoria.IdCategoria,
                (producto, categoria) => new { Producto = producto, Categoria = categoria })
            .Join(_context.UnidadesMedida,
                joinedTables => joinedTables.Producto.IdUnidadMedida,
                unidadMedida => unidadMedida.IdUnidadMedida,
                (joinedTables, unidadMedida) => new { joinedTables.Producto, joinedTables.Categoria, UnidadMedida = unidadMedida })
            .GroupJoin(_context.Plataformas,
                joinedTables => joinedTables.Producto.IdPlataforma,
                plataforma => plataforma.IdPlataforma,
                (joinedTables, plataformasGroup) => new { joinedTables.Producto, joinedTables.Categoria, joinedTables.UnidadMedida, PlataformasGroup = plataformasGroup })
            .SelectMany(joinedTables => joinedTables.PlataformasGroup.DefaultIfEmpty(),
                (joinedTables, plataforma) => new ProductoDtoGet
                {
                    IdProducto = joinedTables.Producto.IdProducto,
                    IdCategoria = joinedTables.Producto.IdCategoria,
                    Categoria = joinedTables.Categoria.Nombre,
                    IdPlataforma = joinedTables.Producto.IdPlataforma,
                    Plataforma = plataforma!.Nombre, //pude que haya que quitar el signo de exclamacion, debido a que plataforma.nombre puede ser null
                    IdUnidadMedida = joinedTables.Producto.IdUnidadMedida,
                    UnidadMedida = joinedTables.UnidadMedida.Nombre,
                    Nombre = joinedTables.Producto.Nombre,
                    Descripcion = joinedTables.Producto.Descripcion,
                    Peso = joinedTables.Producto.Peso,
                    Precio = joinedTables.Producto.Precio,
                    Stock = joinedTables.Producto.Stock,
                    Activo = joinedTables.Producto.Activo,
                    UsuarioModificacion = joinedTables.Producto.UsuarioModificacion
                });

        var result = await query.ToListAsync();

        return result;
    }

    public async Task<ProductoDtoGet> GetProductoDtoById(int idProducto)
    {
        // Se hace un query para incluir "lefts joins" y se filtra por IdProducto
        var query = _context.Productos
            .Join(_context.Categorias,
                producto => producto.IdCategoria,
                categoria => categoria.IdCategoria,
                (producto, categoria) => new { Producto = producto, Categoria = categoria })
            .Join(_context.UnidadesMedida,
                joinedTables => joinedTables.Producto.IdUnidadMedida,
                unidadMedida => unidadMedida.IdUnidadMedida,
                (joinedTables, unidadMedida) => new { joinedTables.Producto, joinedTables.Categoria, UnidadMedida = unidadMedida })
            .GroupJoin(_context.Plataformas,
                joinedTables => joinedTables.Producto.IdPlataforma,
                plataforma => plataforma.IdPlataforma,
                (joinedTables, plataformasGroup) => new { joinedTables.Producto, joinedTables.Categoria, joinedTables.UnidadMedida, PlataformasGroup = plataformasGroup })
            .SelectMany(joinedTables => joinedTables.PlataformasGroup.DefaultIfEmpty(),
                (joinedTables, plataforma) => new ProductoDtoGet
                {
                    IdProducto = joinedTables.Producto.IdProducto,
                    IdCategoria = joinedTables.Producto.IdCategoria,
                    Categoria = joinedTables.Categoria.Nombre,
                    IdPlataforma = joinedTables.Producto.IdPlataforma,
                    Plataforma = plataforma!.Nombre, //pude que haya que quitar el signo de exclamacion, debido a que plataforma.nombre puede ser null
                    IdUnidadMedida = joinedTables.Producto.IdUnidadMedida,
                    UnidadMedida = joinedTables.UnidadMedida.Nombre,
                    Nombre = joinedTables.Producto.Nombre,
                    Descripcion = joinedTables.Producto.Descripcion,
                    Peso = joinedTables.Producto.Peso,
                    Precio = joinedTables.Producto.Precio,
                    Stock = joinedTables.Producto.Stock,
                    Activo = joinedTables.Producto.Activo,
                    UsuarioModificacion = joinedTables.Producto.UsuarioModificacion
                })
            .Where(producto => producto.IdProducto == idProducto);

        var result = await query.SingleOrDefaultAsync();

        return result!;
    }

    public async Task<Producto?> GetProductoById(int idProducto)
    {
        return await _context.Productos.FindAsync(idProducto);
    }
    #endregion get

    #region set
    public async Task<Producto> InsertProducto(ProductoDtoSet productoDTO)
    {
        var producto = new Producto();

        producto.IdCategoria = productoDTO.IdCategoria;
        producto.IdPlataforma = productoDTO.IdPlataforma;
        producto.IdUnidadMedida = productoDTO.IdUnidadMedida;
        producto.Nombre = productoDTO.Nombre;
        producto.Descripcion = productoDTO.Descripcion;
        producto.Peso = productoDTO.Peso;
        producto.Precio = productoDTO.Precio;
        producto.Stock = productoDTO.Stock;
        producto.Activo = productoDTO.Activo;
        producto.UsuarioCreacion = productoDTO.UsuarioModificacion;
        producto.FechaCreacion = DateTime.Now;
        producto.UsuarioModificacion = productoDTO.UsuarioModificacion;
        producto.FechaModificacion = DateTime.Now;

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return producto;
    }
    #endregion set

    #region put
    public async Task<Producto?> UpdateProducto(int idProducto, ProductoDtoSet producto)
    {
        var existeProducto = await GetProductoById(idProducto);
        if (existeProducto is not null)
        {
            existeProducto.IdCategoria = producto.IdCategoria;
            existeProducto.IdPlataforma = producto.IdPlataforma;
            existeProducto.IdUnidadMedida = producto.IdUnidadMedida;
            existeProducto.Nombre = producto.Nombre;
            existeProducto.Descripcion = producto.Descripcion;
            existeProducto.Peso = producto.Peso;
            existeProducto.Precio = producto.Precio;
            existeProducto.Stock = producto.Stock;
            existeProducto.UsuarioModificacion = producto.UsuarioModificacion;
            existeProducto.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return existeProducto;
        }

        return null;
    }

    public async Task<Boolean> DeleteProducto(int idProducto){
        var existeProducto = await GetProductoById(idProducto);
        if(existeProducto is not null){
            existeProducto.Activo = false;

            await _context.SaveChangesAsync();
            return true;
        }

        return false;  
    }
    #endregion put
}