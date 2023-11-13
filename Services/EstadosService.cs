using gamer_store_api.Data;
using gamer_store_api.Data.Models;

namespace gamer_store_api.Services;

public class EstadosService
{
    private readonly GamerStoreContext _context;

    public EstadosService(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    public IEnumerable<Estado> GetEstados()
    {
        return _context.Estados.ToList();
    }

    public Estado? GetEstadoById(int idEstado)
    {
        return _context.Estados.Find(idEstado);
    }
    #endregion get
    
    #region set
    public Estado InsertEstado(Estado estado){
        estado.FechaCreacion = DateTime.Now;
        estado.FechaModificacion = DateTime.Now;
        // estado.FechaModificacion = estado.FechaCreacion;
        //estado.UsuarioCreacion = estado.UsuarioModificacion;

        _context.Estados.Add(estado);
        _context.SaveChanges();

        return estado;
    }
    #endregion set

    #region put
    public Estado? UpdateEstado(int idEstado, Estado estado){
        var existeEstado = GetEstadoById(idEstado);
        if(existeEstado is not null){
            existeEstado.Nombre = estado.Nombre;
            existeEstado.UsuarioModificacion = estado.UsuarioModificacion;
            existeEstado.FechaModificacion = DateTime.Now;

            _context.SaveChanges();
        }

        return existeEstado;
    }

    public void DeleteEstado(int idEstado){
        var existeEstado = GetEstadoById(idEstado);
        if(existeEstado is not null){
            existeEstado.Activo = false;

            _context.SaveChanges();
        }  
    }
    #endregion put

    // #region delete
    // public void DeleteEstado(int idEstado){        
    //     var existeEstado = GetEstadoById(idEstado);
    //     if(existeEstado is not null){
    //         _context.Estados.Remove(existeEstado);
            
    //         _context.SaveChanges();
    //     }
    // }
    // #endregion delete
}