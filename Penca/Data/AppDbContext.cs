using Microsoft.EntityFrameworkCore;
using Penca.Models;

namespace Penca.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Pais> Paises { get; set; }
    public DbSet<Confederacion> Confederaciones { get; set; }
    public DbSet<Deporte> Deportes { get; set; }
}