using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SASContext _context;
    private IReporteGastoRepository _reporteGasto;

    public UnitOfWork(SASContext context)
    {
        _context = context;
    }

    public IReporteGastoRepository ReporteGastos
    {
        get
        {
            if (_reporteGasto == null)
            {
                _reporteGasto = new ReporteGastoRepository(_context);
            }
            return _reporteGasto;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}