using System.Text.Json.Serialization;

namespace Veterinaria.Models; 

public class Propietario
{
    public int PropietarioId { get; set;}
    public string Nombres {get; set;}
    public string Apellidos {get; set;}
    public string Documento {get; set;}
    public string Genero {get; set;}

    [JsonIgnore]
    public virtual ICollection<Mascota> Mascotas { get; set; }

}
