using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{
    public void Configure(EntityTypeBuilder<Factura> builder)
    {

        builder.ToTable("Factura", "Viaticos");

        builder.HasIndex(e => e.UUID, "index_UUID").IsUnique();

        builder.Property(e => e.Id).HasComment("Identificador de la factura").HasColumnName("Id");
        builder.Property(e => e.Estatus)
            .HasDefaultValueSql("((0))")
            .HasComment("0=Factura cancelada, 1=Factura autorizada");
        builder.Property(e => e.FechaInsert)
            .HasDefaultValueSql("(getdate())")
            .HasComment("Fecha de la insercion de la factura")
            .HasColumnType("datetime");
        builder.Property(e => e.FechaTimbrado)
            .HasComment("Fecha del timbrado de la factura")
            .HasColumnType("datetime");
        builder.Property(e => e.ReporteGastoId)
            .HasComment("Identificador del reporte de gastos al que pertenece la factura")
            .HasColumnName("ReporteGastosID");
        builder.Property(e => e.RfCEmisor)
            .HasMaxLength(15)
            .IsUnicode(false)
            .HasComment("RFC del emisor de la factura")
            .HasColumnName("RFCEmisor");
        builder.Property(e => e.RfCReceptor)
            .HasMaxLength(15)
            .IsUnicode(false)
            .HasComment("RFC del receptor de la factura")
            .HasColumnName("RFCReceptor");
        builder.Property(e => e.SelloSat)
            .HasMaxLength(10)
            .IsUnicode(false)
            .HasComment("Sello digital de emisor")
            .HasColumnName("SelloSAT");
        builder.Property(e => e.Total)
            .HasComment("Monto total de la factura")
            .HasColumnType("money");
        builder.Property(e => e.UUID)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasComment("UUID de la factura")
            .HasColumnName("UUID");
        builder.Property(e => e.XmlFactura)
            .HasComment("XML de la factura")
            .HasColumnType("xml");

        builder.HasOne(d => d.ReporteGastos).WithMany(p => p.Facturas)
            .HasForeignKey(d => d.ReporteGastoId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
