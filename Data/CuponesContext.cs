using Microsoft.EntityFrameworkCore;
using Cupones.Models;

namespace Cupones.Data;

public class CuponesContext : DbContext
{
    public CuponesContext(DbContextOptions<CuponesContext> options)
        : base(options)
    {
    }

    public DbSet<Cupon> Cupones { get; set; }

    public DbSet<Campaña> Campañas { get; set; }
    
    public DbSet<Compra> Compras { get; set; }
    
    public DbSet<Empresa> Empresas { get; set; }
    
    public DbSet<Usuario> Usuarios { get; set; }
    
    public DbSet<UsuarioMarketing> UsuariosMarketing { get; set; }
}