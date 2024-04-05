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
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        // Configuração da chave estrangeira para UsuarioModel
        builder.HasOne<UsuarioModel>()
            .WithMany()
            .HasForeignKey(h => h.UsuarioID)
            .OnDelete(DeleteBehavior.Restrict); // Defina o comportamento de exclusão, se necessário

        builder.Property(p => p.StatusMensalidadeId);
        builder.Property(p => p.MesReferencia);
        builder.Property(p => p.AnoReferencia);
 

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
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        // Configuração da propriedade DescricaoStatus
        builder.Property(s => s.DescricaoStatus);
        builder.Property(u => u.status).HasDefaultValue(true);
    }
}
