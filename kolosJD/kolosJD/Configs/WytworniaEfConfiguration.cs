using kolosJD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosJD.Configs;

public class WytworniaEfConfiguration : IEntityTypeConfiguration<Wytwornia>
{
    public void Configure(EntityTypeBuilder<Wytwornia> builder)
    {
        builder.HasKey(x => x.IdWytwornia).HasName("Wytwornia_pk");
        builder.Property(x => x.IdWytwornia).UseIdentityColumn();

        builder.Property(x => x.Nazwa).IsRequired().HasMaxLength(50);

        builder.ToTable(nameof(Wytwornia));

        Wytwornia[] wytwornie =
        {
            new Wytwornia() { IdWytwornia = 1, Nazwa = "Fajna" },
            new Wytwornia() { IdWytwornia = 2, Nazwa = "Niefajna" }
        };

        builder.HasData(wytwornie);
    }
}