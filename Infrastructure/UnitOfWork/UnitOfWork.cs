using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SASContext _context;
    private IReporteGastoRepository _reporteGasto;
    private ICatalogoProdServRepository _catalagoProdServ;
    private IProductoOServicioRepository _productoOServicio;

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

    public ICatalogoProdServRepository CatalogoProdServs
    {
        get
        {
            if (_catalagoProdServ == null)
            {
                _catalagoProdServ = new CatalogoProdServRepository(_context);
            }
            return _catalagoProdServ;
        }
    }

    public IProductoOServicioRepository ProductoOServicios
    {
        get
        {
            if (_productoOServicio == null)
            {
                _productoOServicio = new ProductoOServicioRepository(_context);
            }
            return _productoOServicio;
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