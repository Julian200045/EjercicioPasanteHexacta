using EjercicioPasante.Models;
using Microsoft.EntityFrameworkCore;

namespace EjercicioPasanteHexacta
{
    public class AppPersonasContext: DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        public AppPersonasContext(DbContextOptions<AppPersonasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Persona> personasInit = new List<Persona>();
            personasInit.Add(new Persona(Guid.Parse("b98490f4-fdcd-4185-95dc-8dc2be5063c1"), "Julian", "Carretto", 22, GrupoEtario.Adultos, EstadoCivil.Soltero));

            modelBuilder.Entity<Persona>(persona =>
            {
                persona.HasData(personasInit);
            });
        }
    }
}
