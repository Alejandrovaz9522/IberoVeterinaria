
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Veterinaria.Models;

public class Mascota
{
    public int MascotaId {get;set;} 
    public int PropietarioId { get; set;}
    public string Nombre {get; set;}
    public int TipoId {get; set;}
    public int RazaId {get; set;}
    public string PesoLb {get; set;} 
    public string Genero {get; set;}

    public virtual Propietario Propietario { get; set;}
 
    public virtual Tipo Tipo {get; set;}
   
    public virtual Raza Raza {get; set;} 
  
}
