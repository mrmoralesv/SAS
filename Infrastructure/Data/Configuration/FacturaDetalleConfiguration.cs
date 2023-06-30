using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class FacturaDetalleConfiguration : IEntityTypeConfiguration<FacturaDetalle>
{
    public void Configure(EntityTypeBuilder<FacturaDetalle> builder)
    {
        builder.ToTable("FacturaDetalle", "Viaticos");

        builder.Property(e => e.Cantidad).HasComment("Cantidad de servicios o productos");
        builder.Property(e => e.Descripcion)
            .HasMaxLength(250)
            .IsUnicode(false)
            .HasComment("Descripcion de servicio o producto");
        builder.Property(e => e.FacturaId)
            .HasComment("Identificador de la factura")
            .HasColumnName("FacturaID");
        builder.Property(e => e.Impuestos)
            .HasComment("Impuestos")
            .HasColumnType("money");
        builder.Property(e => e.Notas)
            .HasMaxLength(250)
            .IsUnicode(false)
            .HasComment("Notas para el administrador de los viaticos");
        builder.Property(e => e.ProductoOServicioId)
            .HasComment("Identificador del producto que esta validado para poder facturar,Clave Servicio o Producto")
            .HasColumnName("ProductoOServicioId");
        builder.Property(e => e.ValorUnitario)
            .HasComment("Valor unitario de servicio o producto")
            .HasColumnType("money");

        builder.HasOne(d => d.Factura).WithMany(p => p.FacturaDetalles)
            .HasForeignKey(d => d.FacturaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Viaticos_Factura_FacturaID");
    }
}
