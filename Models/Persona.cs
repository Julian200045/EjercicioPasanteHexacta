using EjercicioPasanteHexacta.DTOS;
using EjercicioPasanteHexacta.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioPasanteHexacta.Models;

    public class Persona
{
    [Key]
    public Guid PersonaId { get; set; } = Guid.NewGuid();

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

    public Persona(string nombre, string apellido, int edad, EstadoCivil estadoCivil)
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        EstadoCivil = estadoCivil;
    }

    static public explicit operator Persona(PersonaDTO dto) => new Persona(dto.Nombre, dto.Apellido, dto.Edad, Enum.Parse<EstadoCivil>(dto.EstadoCivil)); //Ver TryParse TODO
}