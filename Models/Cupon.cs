namespace Cupones.Models;

public class Cupon
{
    public int Id { get; set; }

    public required string Nombre { get; set; }

    public required string Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public required string Valor { get; set; }

    public required int Usabilidad { get; set; }

    public required int UsosDisponibles { get; set; }

    public required string Codigo { get; set; }
    
    public int IdEstado { get; set; }

    public int IdUsuarioMarketing { get; set; }

    public int IdTipoCupon { get; set; }

    public int IdRedimido { get; set; }

    public int IdUsuario { get; set; }

    public int IdTipoUso { get; set; }

    public int IdCampaña { get; set; }
}