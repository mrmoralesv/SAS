namespace Core.Interfaces;

public interface IUnitOfWork
{
    IReporteGastoRepository ReporteGastos { get; }
    ICatalogoProdServRepository CatalogoProdServs { get; }
    IProductoOServicioRepository ProductoOServicios { get; }
    Task<int> SaveAsync();
}
