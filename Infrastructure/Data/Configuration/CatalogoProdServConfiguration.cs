using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

internal class CatalogoProdServConfiguration : IEntityTypeConfiguration<CatalogoProdServ>
{
    public void Configure(EntityTypeBuilder<CatalogoProdServ> builder)
    {
        builder.ToTable("CatalogoProdServ", "Viaticos");

        builder.Property(e => e.Id)
            .HasComment("Identificador de la clase de los productos")
            .HasColumnName("Id");
        builder.Property(e => e.Clase)
            .HasMaxLength(200)
            .HasComment("Clase de la Division");
        builder.Property(e => e.Division)
            .HasMaxLength(200)
            .HasComment("Nombre de la Division");
        builder.Property(e => e.Grupo)
            .HasMaxLength(200)
            .HasComment("grupo de la Division");
    }
}
