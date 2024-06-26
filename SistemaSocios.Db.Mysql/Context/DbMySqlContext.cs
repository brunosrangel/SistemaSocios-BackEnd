﻿using Microsoft.EntityFrameworkCore;
using SistemaSocios.Db.Mysql.Configuration;

public class DbMySqlContext : DbContext
{
    public DbMySqlContext(DbContextOptions<DbMySqlContext> options) : base(options)
    {

    }

    public DbSet<EntidadeModel> Entidades { get; set; }
    public DbSet<HistoricoMensalidadesModel> HistoricoMensalidades { get; set; }
    public DbSet<perfilModel> Perfis { get; set; }
    public DbSet<UsuarioModel> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplica as configurações de entidade
        modelBuilder.ApplyConfiguration(new EntidadeModelConfiguration());
        modelBuilder.ApplyConfiguration(new HistoricoMensalidadesModelConfiguration());
        modelBuilder.ApplyConfiguration(new PerfilModelConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioModelConfiguration());
    }
}