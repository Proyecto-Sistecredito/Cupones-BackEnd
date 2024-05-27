namespace Cupones.Models;

public class Empresa
{
    public int Id { get; set; }
    
    public required string Nombre { get; set; }
    
    public required string Logo { get; set; }
    
    public required string Nit { get; set; }
}