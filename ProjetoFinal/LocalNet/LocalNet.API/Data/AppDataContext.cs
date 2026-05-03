using System;
using LocalNet.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalNet.API.Data;

public class AppDataContext : DbContext
{
    public DbSet<Mensagem> Mensagens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=banco.db");
    }
}
