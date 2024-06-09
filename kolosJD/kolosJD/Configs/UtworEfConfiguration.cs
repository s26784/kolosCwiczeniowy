using kolosJD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosJD.Configs;

public class UtworEfConfiguration : IEntityTypeConfiguration<Utwor>
{
    public void Configure(EntityTypeBuilder<Utwor> builder)
    {
        builder.HasKey(x => x.IdUtwor).HasName("Utwor_pk");
        builder.Property(x => x.IdUtwor).UseIdentityColumn();

        builder.Property(x => x.NazwaUtworu).IsRequired().HasMaxLength(30);

        builder.Property(x => x.CzasTrwania).IsRequired();

        builder.HasOne(x => x.Album)
            .WithMany(x => x.Utwory)
            .HasForeignKey(x => x.IdAlbum)
            .HasConstraintName("Utwor_Album")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(nameof(Utwor));

        Utwor[] utwory =
        {
            new Utwor() { IdUtwor = 1, NazwaUtworu = "BFF", CzasTrwania = 2.54f, IdAlbum = null },
            new Utwor() { IdUtwor = 2, NazwaUtworu = "Lato", CzasTrwania = 6.90f, IdAlbum = null }
        };

        builder.HasData(utwory);

    }
}