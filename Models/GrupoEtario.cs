namespace EjercicioPasante.Models;

public class GrupoEtario
{
    static public List<GrupoEtario> GruposEtarios = new List<GrupoEtario>();

    public string Nombre { get; set; }
    public int Min { get; set; } //Incluido
    public int Max { get; set; } //Incluido

    public GrupoEtario(string nombre, int min, int max) {
        this.Nombre = nombre;
        this.Min = min;
        this.Max = max;

        GruposEtarios.Add(this);
    }
}