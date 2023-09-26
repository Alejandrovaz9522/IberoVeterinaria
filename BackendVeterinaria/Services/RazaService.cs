using Veterinaria.Models;

namespace Veterinaria.Services;

public class RazaService : IRazaService
{
    VeterinariaContext context;

    public RazaService(VeterinariaContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Raza> GetOne(int id)
    {             
        return context.Raza.Where(x => x.RazaId == id).ToList();        
    }

    public IEnumerable<Raza> Get()
    {
        return context.Raza;
    }
}

public interface IRazaService
{
    public IEnumerable<Raza> GetOne(int id);
    public IEnumerable<Raza> Get();
}