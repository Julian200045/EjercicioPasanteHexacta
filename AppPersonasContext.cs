using EjercicioPasanteHexacta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace EjercicioPasanteHexacta
{
    public class AppPersonasContext: DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        public AppPersonasContext(DbContextOptions<AppPersonasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            new GrupoEtario("Niños", 0, 10);
            new GrupoEtario("Adolescentes", 11, 17);
            new GrupoEtario("Adultos", 18, 79);
            new GrupoEtario("Octagenarios", 80, 200);

            try
            {

                var converter = new ValueConverter<GrupoEtario, string>(grupo => grupo.Nombre, nombre => GrupoEtario.GruposEtarios.Find(grupo => grupo.Nombre == nombre));

            modelBuilder
                .Entity<Persona>()
                .Property(persona => persona.GrupoEtario)
                .HasConversion(converter);

            }
            catch (Exception ex) { } //completar TODO

            string query = String.Join("", GrupoEtario.GruposEtarios.Select(grupo => $"WHEN [Edad] BETWEEN {grupo.Min} AND {grupo.Max} THEN '{grupo.Nombre}' ").ToArray());

            modelBuilder.Entity<Persona>()
                .Property(p => p.GrupoEtario)
                .HasComputedColumnSql("CASE " + query + "ELSE 'Otro' END", stored: true);

            List<Persona> personasInit = new List<Persona>();

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
