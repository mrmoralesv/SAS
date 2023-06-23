using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;
public class ReporteGastoRepository : GenericRepository<ReporteGasto>, IReporteGastoRepository
{
    public ReporteGastoRepository(SASContext context) : base(context)
    {
    }

    //public async Task<IEnumerable<ReporteGasto>> GetReporteGastosMasCaros(int cantidad) =>
    //                await _context.ReporteGastos
    //                    .OrderByDescending(p => p.Precio)
    //                    .Take(cantidad)
    //                    .ToListAsync();

    public override async Task<ReporteGasto> GetByIdAsync(int id)
    {
        return await _context.ReporteGastos
                        .Include(p => p.Facturas)
                        .FirstOrDefaultAsync(p => p.Id == id);

    }

    public override async Task<IEnumerable<ReporteGasto>> GetAllAsync()
    {
        return await _context.ReporteGastos
                            .Include(p => p.Facturas)
                            .ToListAsync();
    }

}
