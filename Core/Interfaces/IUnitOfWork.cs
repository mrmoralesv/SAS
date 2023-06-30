namespace Core.Interfaces;

public interface IUnitOfWork
{
    IReporteGastoRepository ReporteGastos { get; }
    ICatalogoProdServRepository CatalogoProdServs { get; }
    Task<int> SaveAsync();
}
