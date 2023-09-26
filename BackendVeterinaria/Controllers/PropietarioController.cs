using Microsoft.AspNetCore.Mvc;
using Veterinaria;
using Veterinaria.Models;
using Veterinaria.Services;

[Route("api/[controller]")]
public class PropietarioController: ControllerBase
{
    protected readonly IClienteService propietarioService; 
    VeterinariaContext context; 

    public PropietarioController(IClienteService service, VeterinariaContext dbContext)
    {
        propietarioService = service; 
        context = dbContext; 
    }

    [HttpGet]
    [Route("CreateDb")]
    public IActionResult CreateDatabase()
    {
        context.Database.EnsureCreated(); 
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var validacion = propietarioService.GetOne(id);
        if (validacion.Count() == 0) 
        {
            return Ok(new { Message = "No existe propietario con ese Id"});
        }
        return Ok(validacion);
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(propietarioService.Get());
    }  

    [HttpPost]
    public IActionResult Post([FromBody] Propietario propietario)
    {
        var validacion = propietarioService.Save(propietario);

        if (validacion.Exception is null)
        {
            return Ok(new { Message = "Propietario Creado Correctamente" });
        }
        else
        {
            return BadRequest(new { Message = validacion.Exception.Message });
        }    
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Propietario propietario)
    {
        var validacion = propietarioService.Update(id, propietario);

        if (validacion.Exception is null)
        {
            return Ok(new { Message = "Propietario Actualizado Correctamente" });
        }
        else
        {
            return BadRequest(new { Message = validacion.Exception.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {             
        var validacion = propietarioService.Delete(id);

        if (validacion.Exception is null)
        {
            return Ok(new { Message = "Propietario Eliminado Correctamente" });
        }
        else
        {
            return BadRequest(new { Message = validacion.Exception.Message });
        }
    }

}