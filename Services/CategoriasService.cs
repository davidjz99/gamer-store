using gamer_store_api.Data;
using gamer_store_api.Data.DTOs;
using gamer_store_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gamer_store_api.Services;

public class CategoriasService
{
    private readonly GamerStoreContext _context;

    public CategoriasService(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    public async Task<IEnumerable<Categoria>> GetCategorias()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<Categoria?> GetCategoriaById(int idCategoria)
    {
        return await _context.Categorias.FindAsync(idCategoria);
    }
    #endregion get

    #region set
    public async Task<Categoria> InsertCategoria(CategoriaDtoSet categoriaDTO){
        var categoria = new Categoria();

        categoria.Nombre = categoriaDTO.Nombre;
        categoria.Descripcion = categoriaDTO.Descripcion;
        categoria.Activo = categoriaDTO.Activo;
        categoria.UsuarioCreacion = categoriaDTO.UsuarioModificacion;
        categoria.FechaCreacion = DateTime.Now;
        categoria.UsuarioModificacion = categoriaDTO.UsuarioModificacion;
        categoria.FechaModificacion = DateTime.Now;

        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return categoria;
    }
    #endregion set

    #region put
    public async Task<Categoria?> UpdateCategoria(int idCategoria, CategoriaDtoSet categoria){
        var existeCategoria = await GetCategoriaById(idCategoria);
        if(existeCategoria is not null){
            existeCategoria.Nombre = categoria.Nombre;
            existeCategoria.Descripcion = categoria.Descripcion;
            existeCategoria.UsuarioModificacion = categoria.UsuarioModificacion;
            existeCategoria.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
            return existeCategoria;
        }

        return null;
    }

    public async Task<Boolean> DeleteCategoria(int idCategoria){
        var existeCategoria = await GetCategoriaById(idCategoria);
        if(existeCategoria is not null){
            existeCategoria.Activo = false;

            await _context.SaveChangesAsync();
            return true;
        }

        return false;  
    }
    #endregion put
}