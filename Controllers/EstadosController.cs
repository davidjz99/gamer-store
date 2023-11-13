using Microsoft.AspNetCore.Mvc;
using gamer_store_api.Data;
using gamer_store_api.Data.Models;

namespace gamer_store_api.Controllers;

[ApiController]
[Route("[controller]")]
public class EstadosController: ControllerBase
{
    private readonly GamerStoreContext _context;
    public EstadosController(GamerStoreContext context)
    {
        _context = context;
    }

    #region get
    [HttpGet]
    public IEnumerable<Estado> GetEstados()
    {
        return _context.Estados.ToList();
    }

    [HttpGet("{idEstado}")]
    public ActionResult<Estado> GetEstadoById(int idEstado)
    {
        Console.WriteLine("entra???");
        var estado = _context.Estados.Find(idEstado);

        if(estado is null){
            return NotFound();
        }
        else{
            return estado;
        }
    }
    #endregion get

    #region set
    [HttpPost]
    public IActionResult InsertEstado(Estado estado){
        estado.FechaCreacion = DateTime.Now;
        estado.FechaModificacion = DateTime.Now;
        // estado.FechaModificacion = estado.FechaCreacion;
        //estado.UsuarioCreacion = estado.UsuarioModificacion;

        _context.Estados.Add(estado);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetEstadoById), new { idEstado = estado.IdEstado }, estado);
    }
    #endregion set

    #region put
    [HttpPut("{idEstado}")]
    public IActionResult UpdateEstado(int idEstado, Estado estado){
        if(idEstado != estado.IdEstado) return BadRequest();

        var existeEstado = _context.Estados.Find(idEstado);
        if(existeEstado is null) return NotFound();

        existeEstado.Nombre = estado.Nombre;
        existeEstado.UsuarioModificacion = estado.UsuarioModificacion;
        existeEstado.FechaModificacion = DateTime.Now;

        _context.SaveChanges();

        return CreatedAtAction(nameof(GetEstadoById), new { idEstado = estado.IdEstado }, estado);
    }

    [HttpPut("delete/{idEstado}")]
    public IActionResult DeleteEstado(int idEstado){
        var existeEstado = _context.Estados.Find(idEstado);
        if(existeEstado is null) return NotFound();

        existeEstado.Activo = false;
        _context.SaveChanges();

        return Ok();
    }
    #endregion put

    // #region delete
    // [HttpDelete("{idEstado}")]
    // public IActionResult DeleteEstado(int idEstado){        
    //     var existeEstado = _context.Estados.Find(idEstado);
    //     if(existeEstado is null) return NotFound();

    //     _context.Estados.Remove(existeEstado);
    //     _context.SaveChanges();

    //     return Ok();
    // }
    // #endregion delete
}