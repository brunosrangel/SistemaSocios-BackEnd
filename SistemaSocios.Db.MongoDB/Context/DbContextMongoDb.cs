using Microsoft.EntityFrameworkCore;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

public class MongoDbContext : DbContext
{
    public MongoDbContext(string connectionString, string databaseName)
    {
        this.Configure(cfg =>
        {
            cfg.ConnectionString = connectionString;
            cfg.Database = databaseName;
        });
    }

    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<EnderecoUsuarioModel> Enderecos { get; set; }
    public DbSet<EscolaridadeUsuarioModel> Escolaridades { get; set; }
    public DbSet<JurosMensalidadeModel> JurosMensalidades { get; set; }
    public DbSet<RedeSocialModel> RedesSociais { get; set; }
    public DbSet<TipoEnderecoUsuarioModel> TiposEndereco { get; set; }
    public DbSet<TipoTelefoneUsuarioModel> TiposTelefone { get; set; }
    public DbSet<ValorMensalidadeModel> ValoresMensalidade { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definir chaves primárias
        modelBuilder.Entity<UsuarioModel>().HasKey(u => u.Id);
        modelBuilder.Entity<EnderecoUsuarioModel>().HasKey(e => e.Id);
        modelBuilder.Entity<EscolaridadeUsuarioModel>().HasKey(e => e.Id);
        modelBuilder.Entity<JurosMensalidadeModel>().HasKey(j => j.Id);
        modelBuilder.Entity<RedeSocialModel>().HasKey(r => r.Id);
        modelBuilder.Entity<TipoEnderecoUsuarioModel>().HasKey(t => t.Id);
        modelBuilder.Entity<TipoTelefoneUsuarioModel>().HasKey(t => t.Id);
        modelBuilder.Entity<ValorMensalidadeModel>().HasKey(v => v.Id);

        // Relacionamentos
        modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.Telefones)
            .WithOne(t => t.Usuario)
            .HasForeignKey(t => t.UsuarioID);

        modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.ValorMensalidades)
            .WithOne(v => v.UsuarioModel)
            .HasForeignKey(v => v.UsuarioID);

        modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.JurosMensalidades)
            .WithOne(j => j.UsuarioModel)
            .HasForeignKey(j => j.UsuarioID);

        modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.HistoricosMensalidades)
            .WithOne(h => h.Usuario)
            .HasForeignKey(h => h.UsuarioID);

        modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.Enderecos)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioID);

        modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.RedesSociais)
            .WithOne(r => r.UsuarioModel)
            .HasForeignKey(r => r.UsuarioID);

        modelBuilder.Entity<EnderecoUsuarioModel>()
            .HasOne(e => e.TipoEndereco)
            .WithMany()
            .HasForeignKey(e => e.TipoEnderecoUsuarioId);

        //modelBuilder.Entity<JurosMensalidadeModel>()
        //    .HasOne(j => j.UsuarioModel)
        //    .WithMany(u => u.JurosMensalidadesModel)
        //    .HasForeignKey(j => j.UsuarioID);

        modelBuilder.Entity<RedeSocialModel>()
            .HasOne(r => r.UsuarioModel)
            .WithMany(u => u.RedesSociais)
            .HasForeignKey(r => r.UsuarioID);
    }
}
