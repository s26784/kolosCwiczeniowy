using kolosJD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolosJD.Configs;

public class WykonawcaUtworuEfConfiguration : IEntityTypeConfiguration<WykonawcaUtworu>
{
    public void Configure(EntityTypeBuilder<WykonawcaUtworu> builder)
    {
        builder.HasKey(x => new { x.IdMuzyk, x.IdUtwor }).HasName("Muzyk_Utwor_pk");

        builder.HasOne(x => x.Muzyk)
            .WithMany(x => x.WykonawcyUtworow)
            .HasForeignKey(x => x.IdMuzyk)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Utwor)
            .WithMany(x => x.WykonawcyUtworow)
            .HasForeignKey(x => x.IdUtwor)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(nameof(WykonawcaUtworu));

        WykonawcaUtworu[] wykonawcyUtworow =
        {
            new WykonawcaUtworu() { IdMuzyk = 1, IdUtwor = 2 },
            new WykonawcaUtworu() { IdMuzyk = 2, IdUtwor = 1 }
        };

        builder.HasData(wykonawcyUtworow);
    }
}