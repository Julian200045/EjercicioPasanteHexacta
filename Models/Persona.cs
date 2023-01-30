using System.ComponentModel.DataAnnotations;

namespace EjercicioPasante.Models;

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

    [Required]
    public GrupoEtario GrupoEtario { get; set; }

    [Required]
    public EstadoCivil EstadoCivil { get; set; }

    public Persona(Guid personaId,string nombre, string apellido, int edad, GrupoEtario grupoEtario, EstadoCivil estadoCivil)
    {
        this.PersonaId = personaId;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Edad = edad;
        this.GrupoEtario= grupoEtario;
        this.EstadoCivil= estadoCivil;
    }
}