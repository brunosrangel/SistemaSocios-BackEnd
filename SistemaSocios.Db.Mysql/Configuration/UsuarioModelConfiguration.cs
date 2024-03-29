using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsuarioModelConfiguration : IEntityTypeConfiguration<UsuarioModel>
{
    public void Configure(EntityTypeBuilder<UsuarioModel> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.nomeUsuario).IsRequired();
        builder.Property(u => u.email).IsRequired();
        builder.Property(u => u.senha);

        builder.HasMany(u => u.endereco)
            .WithOne()
            .HasForeignKey(e => e.Id);

        builder.HasMany(u => u.telefone)
            .WithOne()
            .HasForeignKey(t => t.Id);

        builder.Property(u => u.profissao);
        builder.HasOne(u => u.escolaridade)
                .WithOne()
                .HasForeignKey<EscolaridadeUsuarioModel>(p => p.Id);

        builder.HasMany(u => u.redesocial)
            .WithOne()
            .HasForeignKey(r => r.Id);

        builder.Property(u => u.dataEntrada);
        builder.Property(u => u.dataIniciacao);
        builder.Property(u => u.dataUltimaObrigacao);

        builder.HasMany(u => u.aplicaJurosMensalidade)
            .WithOne()
            .HasForeignKey(j => j.Id);

        builder.HasMany(u => u.Mensalidade)
            .WithOne()
            .HasForeignKey(m => m.Id);

        builder.HasMany(u => u.entidade)
            .WithOne()
            .HasForeignKey(e => e.Id);

        builder.HasOne(u => u.perfilAcesso)
            .WithOne()
            .HasForeignKey<perfilModel>(p => p.Id);
    }

    public void Configure(EntityTypeBuilder<EnderecoUsuarioModel> builder)
    {
        builder.ToTable("EnderecoUsuario");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.cidade);
        builder.Property(p => p.estado);
        builder.Property(p => p.Cep);
        builder.HasOne(p => p.TipoEndereco)
            .WithOne()
            .HasForeignKey<TipoEnderecoUsuarioModel>(p => p.Id);
    }

    public void Configure(EntityTypeBuilder<TelefoneUsuarioModel> builder)
    {
        builder.ToTable("TelefoneUsuario");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.DddTelefoneUsuario).IsRequired();
        builder.Property(t => t.NumeroTelefoneUsuario).IsRequired();

        builder.HasOne(t => t.TipoTelefone)
               .WithMany()
               .HasForeignKey(t => t.Id)
               .OnDelete(DeleteBehavior.Restrict);
    }

    public void Configure(EntityTypeBuilder<EscolaridadeUsuarioModel> builder)
    {
        builder.ToTable("EscolaridadeUsuario");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.DescricaoEscolaridade).IsRequired();
        builder.Property(e => e.StatusEscolaridade).IsRequired();
    }

    public void Configure(EntityTypeBuilder<RedeSocialModel> builder)
    {
        builder.ToTable("RedeSocial");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.DescricaoRedeSocialUsuario).IsRequired();
        builder.Property(r => r.Descricao).IsRequired();
        builder.Property(r => r.UrlRedeSocial).IsRequired();
        builder.Property(r => r.IsActive).IsRequired();
    }

    public void Configure(EntityTypeBuilder<JurosMensalidadeModel> builder)
    {
        builder.ToTable("JurosMensalidade");

        builder.HasKey(j => j.Id);

        builder.Property(j => j.valorJuros).IsRequired();
        builder.Property(j => j.DataVigenciaJuros);
        builder.Property(j => j.statusValorJuros).IsRequired();
    }

    public void Configure(EntityTypeBuilder<ValorMensalidadeModel> builder)
    {
        builder.ToTable("ValorMensalidade");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.ValorMensalidade).IsRequired();
        builder.Property(v => v.VigenciaMensalidade).IsRequired();
        builder.Property(v => v.statusValorMensalidade).IsRequired();
    }
}