namespace Core.Interfaces;

public interface IUnitOfWork
{
    IReporteGastoRepository ReporteGastos { get; }
    Task<int> SaveAsync();
}
