using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
                        .ThenInclude(f => f.FacturaDetalles)
                        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<ReporteGasto>> GetAllAsync()
    {
        return await _context.ReporteGastos
                            .Include(p => p.Facturas)
                            .ThenInclude(f => f.FacturaDetalles)
                            .Where(p => p.Estatus == false)
                            .ToListAsync();
    }

    public async Task<IEnumerable<ReportePendienteDto>> GetAllPendientesAsync()
    {
        var query = @"EXECUTE SpVticosReportes 1,0,''";

        using (var connection = _context.Database.GetDbConnection())
        {
            var reportesPendientes = await connection.QueryAsync<ReportePendienteDto> (query);
            
            return reportesPendientes;
        }
    }

}
