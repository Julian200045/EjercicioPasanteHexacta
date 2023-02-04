using EjercicioPasanteHexacta.Models;
using System.Runtime.CompilerServices;

namespace EjercicioPasanteHexacta.Services
{
    public class PersonaService: IPersonaService
    {
        AppPersonasContext context;

        public PersonaService(AppPersonasContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Persona> Get(string nombre, string apellido)
        {
            return context.Personas.Where(persona => persona.Nombre.Contains(nombre) && persona.Apellido.Contains(apellido));
        }

        public async Task Save(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
        }
    }

    public interface IPersonaService
    {
        IEnumerable<Persona> Get(string nombre, string apellido);

        Task Save(Persona persona);
    }
}

