namespace Cupones.Models;

public class UsuarioMarketing
{
    public int Id { get; set; }
    
    public required string Nombre { get; set; }
    
    public required string Apellido { get; set; }
    
    public required string Email { get; set; }
    
    public required string Contraseña { get; set; }
    
    public required string Documento { get; set; }
    
    public int IdTipoDocumento { get; set; }
}