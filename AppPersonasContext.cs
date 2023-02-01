using EjercicioPasante.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EjercicioPasanteHexacta
{
    public class AppPersonasContext: DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        public AppPersonasContext(DbContextOptions<AppPersonasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Persona> personasInit = new List<Persona>();

            modelBuilder.Entity<Persona>()
                .Property(p => p.GrupoEtario)
                .HasComputedColumnSql("CASE " +
                    $"WHEN [Edad] BETWEEN 0 AND 11 THEN {(int)GrupoEtario.Niños} " +
                    $"WHEN [Edad] BETWEEN 11 AND 18 THEN {(int)GrupoEtario.Adolescentes} " +
                    $"WHEN [Edad] BETWEEN 18 AND 80 THEN {(int)GrupoEtario.Adultos} " +
                    $"ELSE {(int)GrupoEtario.Octagenarios} " +
                    $"END", stored: true); ;

            personasInit.Add(new Persona(Guid.Parse("b98490f4-fdcd-4185-95dc-8dc2be5063c1"), "Julian", "Carretto", 22, EstadoCivil.Soltero));
            personasInit.Add(new Persona(Guid.Parse("b98490f4-fdcd-4185-95dc-8dc2be5063c2"), "Camila", "Carretto", 24, EstadoCivil.Soltero));
            personasInit.Add(new Persona(Guid.Parse("b98490f4-fdcd-4185-95dc-8dc2be5063c3"), "Valeria", "Chanquia", 22, EstadoCivil.Soltero));
            personasInit.Add(new Persona(Guid.Parse("b98490f4-fdcd-4185-95dc-8dc2be5063c4"), "Pepe", "Argento", 8, EstadoCivil.Soltero));
            personasInit.Add(new Persona(Guid.Parse("b98490f4-fdcd-4185-95dc-8dc2be5063c5"), "Claudio", "Chavez", 12, EstadoCivil.Soltero));
            personasInit.Add(new Persona(Guid.Parse("b98490f4-fdcd-4185-95dc-8dc2be5063c6"), "Jorge", "Perez", 80, EstadoCivil.Soltero));

            modelBuilder.Entity<Persona>(persona =>
            {
                persona.HasData(personasInit);
            });
        }

    }
}
