using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;
namespace Veterinaria.Services; 

public class MascotaService : IMascotaService
{
    VeterinariaContext context; 
    
    public MascotaService(VeterinariaContext dbContext)
    {
        context = dbContext; 
    }

    public IEnumerable<Mascota> GetOne(int id)
    {
        return context.Mascota.Where(x => x.MascotaId == id).ToList();
    }

    public IEnumerable<Mascota> Get()
    {
        return context.Mascota.Include(p => p.Propietario).Include(p => p.Raza).Include(p => p.Tipo); 
    }

    public async Task Save(Mascota mascota)
    {
        if (mascota is null)
        {
            throw new ArgumentNullException(nameof(mascota));
        }

        var validarPropietario = context.Propietario.Where(p => p.PropietarioId == mascota.PropietarioId).ToList();
        var validarTipo = context.Tipo.Where(p => p.TipoId == mascota.TipoId).ToList();
        var validarRaza = context.Raza.Where(p => p.RazaId == mascota.RazaId).ToList();

        if (validarPropietario.Count > 0)
        {
            if (validarTipo.Count > 0)
            {
                if (validarRaza.Count > 0)
                {
                    context.Mascota.Add(mascota);
                    await context.SaveChangesAsync();
                }
                else throw new Exception("Raza no existe en la base de datos");
            }
            else throw new Exception("Tipo no existe en la base de datos");
        }
        else throw new Exception("Propietario no existe en la base de datos");
    }

    public async Task Update(int id, Mascota mascota)
    {
        var mascotaActual = context.Mascota.Find(id);

        var validarMascota = context.Mascota.Where(p => p.MascotaId == id).ToList();
        var validarPropietario = context.Propietario.Where(p => p.PropietarioId == mascota.PropietarioId).ToList();
        var validarTipo = context.Tipo.Where(p => p.TipoId == mascota.TipoId).ToList();
        var validarRaza = context.Raza.Where(p => p.RazaId == mascota.RazaId).ToList();

        if (mascotaActual != null)
        {
            if (validarMascota.Count > 0)
            {
                if (validarPropietario.Count > 0)
                {
                    if (validarTipo.Count > 0)
                    {
                        if (validarRaza.Count > 0)
                        {                        
                            mascotaActual.PropietarioId = mascota.PropietarioId;
                            mascotaActual.Nombre = mascota.Nombre;
                            mascotaActual.TipoId = mascota.TipoId;
                            mascotaActual.RazaId = mascota.RazaId;
                            mascotaActual.Genero = mascota.Genero;
                            mascotaActual.PesoLb = mascota.PesoLb;
                            await context.SaveChangesAsync();                        
                        }
                        else throw new Exception("Raza no existe en la base de datos");
                    }
                    else throw new Exception("Tipo no existe en la base de datos");
                }
                else throw new Exception("Propietario no existe en la base de datos");
            }
            else throw new Exception("Mascota no existe en la base de datos");
        }
        else throw new Exception("Sin datos");
    }

    public async Task Delete(int id)
    {
        var mascotaActual = context.Mascota.Find(id);

        if(mascotaActual != null)
        {        
            context.Remove(mascotaActual);
            await context.SaveChangesAsync();
        }
        else throw new Exception("Mascota no existe en la base de datos");
    }
}

public interface IMascotaService
{
    public IEnumerable<Mascota> GetOne(int id);
    public IEnumerable<Mascota> Get();
    public Task Save(Mascota mascota);
    public Task Update(int id, Mascota mascota);
    public Task Delete(int id);
}