using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class SaldoDetalleConfiguration : IEntityTypeConfiguration<SaldoDetalle>
{
    public void Configure(EntityTypeBuilder<SaldoDetalle> builder)
    {
        builder.ToTable("SaldoDetalle", "Cobranza");

        builder.Property(e => e.Descripcion)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasComment("Descripcion del aumento o disminucion de saldo");
        builder.Property(e => e.SaldoAD)
            .HasComment("Aumentos y disminuciones de saldo")
            .HasColumnType("money");
        builder.Property(e => e.SaldoId)
            .HasComment("Identificador del aumento o disminucion de saldo")
            .HasColumnName("SaldoID");

        builder.HasOne(d => d.Saldo).WithMany()
            .HasForeignKey(d => d.SaldoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Cobranza_Saldo_SaldoID");
    }
}