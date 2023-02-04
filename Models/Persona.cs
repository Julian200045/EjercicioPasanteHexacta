using EjercicioPasanteHexacta.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioPasanteHexacta.Models;

    public class Persona
{
    [Key]
    public Guid PersonaId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Nombre { get; set; }

    [Required]
    [MaxLength(255)]
    public string Apellido{ get; set; }

    [Required]
    public int Edad { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public GrupoEtario GrupoEtario { get; set; }

    [Required]
    public EstadoCivil EstadoCivil { get; set; }

    public Persona(Guid personaId,string nombre, string apellido, int edad, EstadoCivil estadoCivil)
    {
        PersonaId = personaId;
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        EstadoCivil = estadoCivil;
    }

    //public static explicit operator PersonaView(Persona persona) => new PersonaView(persona);
}