using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;

namespace Infrastructure.Data;

public class SASContext : DbContext
{
    public SASContext()
    {
    }

    public SASContext(DbContextOptions<SASContext> options) : base(options)
    {
    }

    public  DbSet<CatalogoProdServ> CatalogoProdServ { get; set; }

    public  DbSet<DatabaseLog> DatabaseLogs { get; set; }

    public  DbSet<Factura> Facturas { get; set; }

    public  DbSet<FacturaDetalle> FacturaDetalles { get; set; }

    public  DbSet<ProductoOServicio> ProductoOServicio { get; set; }

    public  DbSet<ReporteGasto> ReporteGastos { get; set; }

    public  DbSet<Saldo> Saldos { get; set; }

    public  DbSet<SaldoDetalle> SaldoDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Configuraciones
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}
