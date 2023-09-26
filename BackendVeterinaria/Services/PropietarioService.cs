using Microsoft.AspNetCore.Mvc;
using Veterinaria.Models;
namespace Veterinaria.Services; 

public class PropietarioService : IClienteService
{
    VeterinariaContext context; 
    
    public PropietarioService(VeterinariaContext dbContext)
    {
        context = dbContext; 
    }

    public IEnumerable<Propietario> GetOne(int id)
    {             
        return context.Propietario.Where(x => x.PropietarioId == id).ToList();        
    }

    public IEnumerable<Propietario> Get()
    {
        return context.Propietario; 
    }

    public async Task Save(Propietario cliente)
    {
        context.Add(cliente);
        await context.SaveChangesAsync();
    }

    public async Task Update(int id, Propietario propietario)
    {
        var clienteActual = context.Propietario.Find(id);

        if(clienteActual != null)
        {
            clienteActual.Nombres = propietario.Nombres;
            clienteActual.Apellidos = propietario.Apellidos; 
            clienteActual.Documento = propietario.Documento;
            clienteActual.Genero = propietario.Genero;
            await context.SaveChangesAsync();
        }
        else throw new Exception("Propietario no existe en la base de datos");
    }

    public async Task Delete(int id)
    {
        var clienteActual = context.Propietario.Find(id);

        if(clienteActual != null)
        {        
            context.Remove(clienteActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface IClienteService
{
    public IEnumerable<Propietario> GetOne(int id);
    public IEnumerable<Propietario> Get();
    public Task Save(Propietario cliente);
    public Task Update(int id, Propietario cliente);
    public Task Delete(int id);
}