using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PerfilModelConfiguration : IEntityTypeConfiguration<perfilModel>
{
    public void Configure(EntityTypeBuilder<perfilModel> builder)
    {
        // Define o nome da tabela como "Perfis"
        builder.ToTable("Perfis");

        // Define a chave primária
        builder.HasKey(p => p.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        // Configuração das propriedades DescricaoPerfil e StatusPerfil
        builder.Property(p => p.DescricaoPerfil).IsRequired();
 

    }
}
