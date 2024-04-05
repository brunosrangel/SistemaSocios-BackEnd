using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsuarioModelConfiguration : IEntityTypeConfiguration<UsuarioModel>
{

    public void Configure(EntityTypeBuilder<UsuarioModel> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        // Configuração do campo status
        builder.Property(u => u.status).IsRequired().HasDefaultValue(true);

        // Outras propriedades e associações...
        builder.Property(u => u.NomeUsuario).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Senha);

        builder.HasMany(u => u.RedesSociais)
               .WithOne(r => r.UsuarioModel) // Supondo que RedesSociais tenha uma propriedade de navegação chamada Usuarios
               .HasForeignKey(u => u.UsuarioID)
               .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com outras entidades
        builder.HasMany(u => u.Telefones)
               .WithOne(t => t.Usuario)
               .HasForeignKey(t => t.UsuarioID) // Corrigido para usar a propriedade correta
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.ValorMensalidades)
               .WithOne(t => t.UsuarioModel)
               .HasForeignKey(v => v.UsuarioID) // Corrigido para usar a propriedade correta
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.JurosMensalidades)
              .WithOne(t => t.UsuarioModel)
               .HasForeignKey(v => v.UsuarioID) // Corrigido para usar a propriedade correta
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.HistoricosMensalidades)
               .WithOne(t => t.Usuario)
               .HasForeignKey(v => v.UsuarioID) // Corrigido para usar a propriedade correta
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Enderecos)
               .WithOne(t => t.Usuario)
               .HasForeignKey(v => v.UsuarioID) // Corrigido para usar a propriedade correta
               .OnDelete(DeleteBehavior.Restrict);
    }






    public void Configure(EntityTypeBuilder<EnderecoUsuarioModel> builder)
    {
        builder.ToTable("EnderecoUsuario");
        builder.HasKey(e => e.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Endereco).IsRequired();
        builder.Property(e => e.Cidade).IsRequired();
        builder.Property(e => e.Estado).IsRequired();
        builder.Property(e => e.Cep).IsRequired();

        builder.HasOne(e => e.TipoEndereco)
            .WithMany()
            .HasForeignKey(e => e.TipoEnderecoUsuarioId)
            .IsRequired();

        // Relacionamento com UsuarioModel
        builder.HasOne(e => e.Usuario)
            .WithMany(u => u.Enderecos) // Um usuário pode ter vários endereços
            .HasForeignKey(e => e.UsuarioID)
            .IsRequired();
 

    }

    public void Configure(EntityTypeBuilder<TelefoneUsuarioModel> builder)
    {
        builder.ToTable("TelefoneUsuario");

        builder.HasKey(t => t.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        builder.Property(t => t.DddTelefoneUsuario).IsRequired();
        builder.Property(t => t.NumeroTelefoneUsuario).IsRequired();

        builder.HasOne(t => t.TipoTelefone)
               .WithMany()
               .HasForeignKey(t => t.TipoTelefoneUsuarioId)
               .OnDelete(DeleteBehavior.Restrict);
 


    }

    public void Configure(EntityTypeBuilder<EscolaridadeUsuarioModel> builder)
    {
        builder.ToTable("EscolaridadeUsuario");

        builder.HasKey(e => e.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.DescricaoEscolaridade).IsRequired();
 


    }

    public void Configure(EntityTypeBuilder<RedeSocialModel> builder)
    {
        builder.ToTable("RedeSocial");

        builder.HasKey(r => r.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        builder.Property(r => r.DescricaoRedeSocialUsuario).IsRequired();
        builder.Property(r => r.Descricao).IsRequired();
        builder.Property(r => r.UrlRedeSocial).IsRequired();
 

    }

    public void Configure(EntityTypeBuilder<JurosMensalidadeModel> builder)
    {
        builder.ToTable("JurosMensalidade");

        builder.HasKey(j => j.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        builder.Property(j => j.valorJuros).IsRequired();
        builder.Property(j => j.DataVigenciaJuros);
        builder.Property(j => j.statusValorJuros).IsRequired();
        builder.Property(u => u.status).HasDefaultValue(true);

    }

    public void Configure(EntityTypeBuilder<ValorMensalidadeModel> builder)
    {
        builder.ToTable("ValorMensalidade");

        builder.HasKey(v => v.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(v => v.ValorMensalidade).IsRequired();
        builder.Property(v => v.VigenciaMensalidade).IsRequired();
        builder.Property(v => v.statusValorMensalidade).IsRequired();
        builder.Property(u => u.status).HasDefaultValue(true);

    }
}