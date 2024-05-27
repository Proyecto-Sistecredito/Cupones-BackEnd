namespace Cupones.Models;

public class Campaña
{
    public int Id { get; set; }

    public required string Nombre { get; set; }

    public required string Descripcion { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int IdEmpresa { get; set; }
}