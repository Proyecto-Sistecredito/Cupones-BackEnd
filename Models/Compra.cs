namespace Cupones.Models;

public class Compra
{
    public int Id { get; set; }

    public required int ValorCompra { get; set; }

    public required DateTime FechaCompra { get; set; }

    public required int IdUsuario { get; set; }

    public required int IdCupon { get; set; }
}