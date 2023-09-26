using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Services;

namespace Veterinaria.Controllers;

[Route("api/[controller]")]
public class TipoController : ControllerBase
{
    protected readonly ITipoService tipoService;

    public TipoController(ITipoService service)
    {
        tipoService = service;
    }

    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var validacion = tipoService.GetOne(id);
        if (validacion.Count() == 0) 
        {
            return Ok(new { Message = "No existe tipo con ese Id"});
        }
        return Ok(validacion);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tipoService.Get());
    }
}

