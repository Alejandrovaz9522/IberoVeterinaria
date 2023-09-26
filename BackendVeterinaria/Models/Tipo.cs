using System.Text.Json.Serialization;

namespace Veterinaria.Models;

public class Tipo 
{
    public int TipoId {get;set;}
    public string DescripcionTipo {get;set;}

    [JsonIgnore]
    public virtual ICollection<Mascota> Mascotas {get; set;}
}