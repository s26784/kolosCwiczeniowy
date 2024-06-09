using kolosJD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosJD.Configs;

public class AlbumEfConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(x => x.IdAlbum).HasName("Album_pk");
        builder.Property(x => x.IdAlbum).UseIdentityColumn();

        builder.Property(x => x.NazwaAlbumu).HasMaxLength(30).IsRequired();
        
        builder.Property(x=>x.DataWydania).IsRequired().HasDefaultValueSql("GETDATE()");

        builder.HasOne(x => x.Wytwornia)
            .WithMany(x => x.Albumy)
            .HasForeignKey(x => x.IdWytwornia)
            .HasConstraintName("Album_Wytwornia_pk")
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(nameof(Album));

        Album[] albumy =
        {
            new Album()
            {
                IdAlbum = 1, DataWydania = new DateTime(2002, 12, 12), NazwaAlbumu = "To od Gangu Albanii",
                IdWytwornia = 1
            },
            new Album()
            {
                IdAlbum = 2, DataWydania = new DateTime(2020, 03, 08), NazwaAlbumu = "Cos tam", IdWytwornia = 1
            }
        };

        builder.HasData(albumy);
        

    }
}