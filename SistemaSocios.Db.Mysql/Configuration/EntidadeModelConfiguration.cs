using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaSocios.Db.Mysql.Configuration
{
    public class EntidadeModelConfiguration : IEntityTypeConfiguration<EntidadeModel>
    {
        public void Configure(EntityTypeBuilder<EntidadeModel> builder)
        {
            builder.ToTable("Entidades");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.DescricaoEntidade);
            builder.Property(u => u.statusEntidade);

        }
    }
}
