using Microsoft.EntityFrameworkCore;
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

// Configuração do relacionamento TelefoneUsuarioModel - TipoTelefoneUsuarioModel
        modelBuilder.Entity<TelefoneUsuarioModel>()
            .HasOne(t => t.TipoTelefone)
            .WithMany() // Remova WithMany se TipoTelefoneUsuarioModel não tiver uma propriedade de navegação para telefones
            .HasForeignKey(t => t.TipoTelefoneUsuarioId); // Aqui está a chave estrangeira em TelefoneUsuarioModel

        // Configuração do relacionamento EnderecoUsuario - TipoEndereco
        modelBuilder.Entity<EnderecoUsuarioModel>()
             .HasOne(e => e.TipoEndereco)
             .WithMany() // Um tipo de endereço pode estar em muitos endereços
             .HasForeignKey(e => e.TipoEnderecoUsuarioId);
    
        modelBuilder.Entity<EnderecoUsuarioModel>()
            .HasOne(e => e.Usuario)
            .WithMany(u => u.Enderecos) // Um usuário pode ter muitos endereços
            .HasForeignKey(e => e.UsuarioID);


        //Um para Muitos

        modelBuilder.Entity<UsuarioModel>()
          .HasMany(u => u.HistoricosMensalidades)
          .WithOne() // Não é necessário especificar a propriedade de navegação aqui
          .HasForeignKey(h => h.UsuarioID)
          .IsRequired();

        modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.JurosMensalidades)
            .WithOne()
            .HasForeignKey(m => m.UsuarioID) // Usar a chave estrangeira diretamente
            .IsRequired();

        modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.RedesSociais)
            .WithOne()
            .HasForeignKey(m => m.UsuarioID) // Usar a chave estrangeira diretamente
            .IsRequired();

        modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.Telefones) // Propriedade de navegação para a lista de mensalidades
            .WithOne() // Propriedade de navegação para o usuário em ValorMensalidadeModel
            .HasForeignKey(m => m.UsuarioID) // Chave estrangeira em ValorMensalidadeModel
            .IsRequired(); // ou .IsRequired(false) para torná-lo opcional

        modelBuilder.Entity<UsuarioModel>()
            .HasMany(u => u.Enderecos) // Propriedade de navegação para a lista de mensalidades
            .WithOne() // Propriedade de navegação para o usuário em ValorMensalidadeModel
            .HasForeignKey(m => m.UsuarioID) // Chave estrangeira em ValorMensalidadeModel
            .IsRequired(); // ou .IsRequired(false) para torná-lo opcional


        base.OnModelCreating(modelBuilder);

        // Aplica as configurações de entidade
        modelBuilder.ApplyConfiguration(new EntidadeModelConfiguration());
        modelBuilder.ApplyConfiguration(new HistoricoMensalidadesModelConfiguration());
        modelBuilder.ApplyConfiguration(new PerfilModelConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioModelConfiguration());
    }


}