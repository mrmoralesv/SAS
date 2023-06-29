using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class SaldoConfiguration : IEntityTypeConfiguration<Saldo>
{
    public void Configure(EntityTypeBuilder<Saldo> builder)
    {

        builder.ToTable("Saldo", "Cobranza");

        builder.Property(e => e.Id).HasComment("Identificador para cada uno de los aumentos o disminuciones de saldo").HasColumnName("Id");
        builder.Property(e => e.Descripcion)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.PersonalId)
            .HasComment("Identificador personal del trabajador")
            .HasColumnName("ID_PERSONAL");
        builder.Property(e => e.SaldoAD)
            .HasComment("Aumentos y disminuciones de saldo")
            .HasColumnType("money")
            .HasColumnName("SaldoAD");
    }
}