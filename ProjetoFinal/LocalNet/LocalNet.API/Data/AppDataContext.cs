using LocalNet.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalNet.API.Data;

public class AppDataContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioGrupo> UsuarioGrupos { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LocalNetBanco.db");
    }
}