using kolosJD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosJD.Configs;

public class MuzykEfConfiguration : IEntityTypeConfiguration<Muzyk>
{
    public void Configure(EntityTypeBuilder<Muzyk> builder)
    {
        builder.HasKey(x => x.IdMuzyk).HasName("Muzyk_pk");
        builder.Property(x => x.IdMuzyk).UseIdentityColumn();

        builder.Property(x => x.Imie).IsRequired().HasMaxLength(30);

        builder.Property(x => x.Nazwisko).IsRequired().HasMaxLength(40);

        builder.Property(x => x.Pseudonim).HasMaxLength(50);

        builder.ToTable(nameof(Muzyk));

        Muzyk[] muzycy =
        {
            new Muzyk() { IdMuzyk = 1, Imie = "Tomasz", Nazwisko = "Malaka", Pseudonim = "MalaczekUwU" },
            new Muzyk() { IdMuzyk = 2, Imie = "Leokadia", Nazwisko = "Mloda", Pseudonim = "Leosia" }
        };

        builder.HasData(muzycy);
    }
}