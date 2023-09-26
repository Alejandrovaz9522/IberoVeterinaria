using System.Text.Json.Serialization;

namespace Veterinaria.Models;

public class Raza 
{
    public int RazaId {get;set;}
    public string DescripcionRaza {get;set;}

    [JsonIgnore]
    public virtual ICollection<Mascota> Mascotas {get; set;}
    
}