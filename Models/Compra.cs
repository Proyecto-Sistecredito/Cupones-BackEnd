namespace Cupones.Models;

public class Compra
{
    public int Id { get; set; }

    public required string ValorCompra { get; set; }

    public required string FechaCompra { get; set; }

    public required string IdUsuario { get; set; }

    public required string IdCupon { get; set; }
}