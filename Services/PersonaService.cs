using EjercicioPasante.Models;

namespace EjercicioPasanteHexacta.Services
{
    public class PersonaService: IPersonaService
    {
        AppPersonasContext context;

        public PersonaService(AppPersonasContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Persona> Get()
        {
            return context.Personas;
        }

        public async Task Save(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
        }
    }

    public interface IPersonaService
    {
        IEnumerable<Persona> Get();

        Task Save(Persona persona);
    }
}

