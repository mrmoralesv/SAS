using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ReporteGastoConfiguration : IEntityTypeConfiguration<ReporteGasto>
{
    public void Configure(EntityTypeBuilder<ReporteGasto> builder)
    {

        builder.ToTable("ReporteGastos", "Viaticos");

        builder.Property(e => e.Id).HasComment("Identificador para los cada uno de los reportes de gastos").HasColumnName("Id");
        builder.Property(e => e.Estatus)
            .HasDefaultValueSql("((0))")
            .HasComment("0=No validado 1=Validado");
        builder.Property(e => e.FechaFin)
            .HasComment("Fecha fin del reporte de gastos")
            .HasColumnType("datetime");
        builder.Property(e => e.FechaInicio)
            .HasComment("Fecha inicio del reporte de gastos")
            .HasColumnType("datetime");
        builder.Property(e => e.FechaInsert)
            .HasDefaultValueSql("(getdate())")
            .HasComment("Fecha en que se genero el reporte de gastos")
            .HasColumnType("datetime");
        builder.Property(e => e.ViaticoId)
            .HasComment("Idetificador para cada uno de los viaticos")
            .HasColumnName("ID_VIATICO");
    }
}