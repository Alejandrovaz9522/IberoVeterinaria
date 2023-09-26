using Veterinaria.Models;
namespace Veterinaria.Services;

public class TipoService: ITipoService
{
    VeterinariaContext context;

    public TipoService(VeterinariaContext dbContext)
    {
        context = dbContext;
    }

    public IEnumerable<Tipo> GetOne(int id)
    {             
        return context.Tipo.Where(x => x.TipoId == id).ToList();        
    }

    public IEnumerable<Tipo> Get()
    {
        return context.Tipo;
    }
}

public interface ITipoService
{
    public IEnumerable<Tipo> GetOne(int id);
    public IEnumerable<Tipo> Get();
}