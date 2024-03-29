using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HistoricoMensalidadesModelConfiguration : IEntityTypeConfiguration<HistoricoMensalidadesModel>
{
    public void Configure(EntityTypeBuilder<HistoricoMensalidadesModel> builder)
    {
        // Define o nome da tabela como "HistoricoMensalidades"
        builder.ToTable("HistoricoMensalidades");

        // Define a chave primária
        builder.HasKey(h => h.Id);

        // Configuração da chave estrangeira para UsuarioModel
        builder.HasOne(h => h.Usuario)
            .WithMany()
            .HasForeignKey(h => h.UsuarioID)
            .OnDelete(DeleteBehavior.Restrict); // Defina o comportamento de exclusão, se necessário

        // Configuração da chave estrangeira para StatusMensalidadeModel
        builder.HasOne(h => h.statusMensalidade)
            .WithMany()
            .HasForeignKey(h => h.StatusMensalidadeId)
            .OnDelete(DeleteBehavior.Restrict); // Defina o comportamento de exclusão, se necessário

        // Configuração das propriedades MesReferencia e AnoReferencia
        builder.Property(h => h.MesReferencia);
        builder.Property(h => h.AnoReferencia);
    }
}

public class StatusMensalidadeModelConfiguration : IEntityTypeConfiguration<StatusMensalidadeModel>
{
    public void Configure(EntityTypeBuilder<StatusMensalidadeModel> builder)
    {
        // Define o nome da tabela como "StatusMensalidade"
        builder.ToTable("StatusMensalidade");

        // Define a chave primária
        builder.HasKey(s => s.Id);

        // Configuração da propriedade DescricaoStatus
        builder.Property(s => s.DescricaoStatus);
    }
}
