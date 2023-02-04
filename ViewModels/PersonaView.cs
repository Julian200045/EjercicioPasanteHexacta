using EjercicioPasanteHexacta.Models;

namespace EjercicioPasanteHexacta.ViewModels
{
    public class PersonaView
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string GrupoEtario { get; set; }
        public string EstadoCivil { get; set; }


        // posible refactor dependiendo request post
        public PersonaView(string nombre,string apellido,int edad,string grupoEtario, string estadoCivil) {

            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.GrupoEtario = grupoEtario;
            this.EstadoCivil = estadoCivil; 
            
        }

        static public explicit operator PersonaView(Persona persona) => new PersonaView(persona.Nombre, persona.Apellido, persona.Edad, persona.GrupoEtario.Nombre, persona.EstadoCivil.ToString());
    }
}
