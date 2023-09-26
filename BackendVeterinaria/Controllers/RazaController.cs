using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Models;
using Veterinaria.Services;

namespace Veterinaria.Controllers;

[Route("api/[controller]")]
public class RazaController : ControllerBase
{
    protected readonly IRazaService razaService;

    public RazaController(IRazaService service)
    {
        razaService = service;
    }

    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var validacion = razaService.GetOne(id);
        if (validacion.Count() == 0) 
        {
            return Ok(new { Message = "No existe raza con ese Id"});
        }
        return Ok(validacion);
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(razaService.Get() );
    }
}

