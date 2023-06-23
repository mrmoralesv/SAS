using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ProductoValidoConfiguration : IEntityTypeConfiguration<ProductoValido>
{
    public void Configure(EntityTypeBuilder<ProductoValido> builder)
    {

        builder.ToTable("ProductoValido", "Viaticos");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasComment("Identificador del producto que esta validado para poder facturar,Clave Servicio o Producto")
            .HasColumnName("Id");
        builder.Property(e => e.CatalogoProductoId)
            .HasComment("Identificador para clasificacion del producto")
            .HasColumnName("CatalogoProductoID");
        builder.Property(e => e.Estatus)
            .HasDefaultValueSql("((1))")
            .HasComment("0= Producto no valido para SINCI 1=Producto valido para SINCI");
        builder.Property(e => e.FechaInsert)
            .HasDefaultValueSql("(getdate())")
            .HasComment("Fecha en que se inserto el producto")
            .HasColumnType("datetime");
        builder.Property(e => e.NombreProducto)
            .HasMaxLength(200)
            .IsUnicode(false)
            .HasComment("Descripcion del producto");
    }
}