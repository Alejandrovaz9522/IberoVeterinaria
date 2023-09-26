using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Veterinaria;
using Veterinaria.Models;
using Veterinaria.Services;

[Route("api/[controller]")]
public class MascotaController: ControllerBase
{
    protected readonly IMascotaService mascotaService;
    VeterinariaContext context;

    public MascotaController(IMascotaService service)
    {
        mascotaService = service; 
    }

    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var validacion = mascotaService.GetOne(id);
        if (validacion.Count() == 0)
        {
            return Ok(new { Message = "No existe propietario con ese Id" });
        }
        return Ok(validacion);
        
    }  

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(mascotaService.Get());
    }  

    [HttpPost]
    public IActionResult Post([FromBody] Mascota mascota)
    {      
        var validacion = mascotaService.Save(mascota);

        if (validacion.Exception is null)
        {
            return Ok( new { Message = "Mascota Creada Correctamente" }); 
        }
        else
        {
            return BadRequest( new { Message = validacion.Exception.Message });
        }
        
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Mascota mascota)
    {
        var validacion = mascotaService.Update(id, mascota);

        if (validacion.Exception is null)
        {
            return Ok(new { Message = "Mascota Actualizada Correctamente" });
        }
        else
        {
            return BadRequest(new { Message = validacion.Exception.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {

        var validacion = mascotaService.Delete(id);

        if (validacion.Exception is null)
        {
            return Ok(new { Message = "Mascota Eliminada Correctamente" });
        }
        else
        {
            return BadRequest(new { Message = validacion.Exception.Message });
        }        
    }

}