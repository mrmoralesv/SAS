using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces;

public interface IReporteGastoRepository : IGenericRepository<ReporteGasto>
{
    Task<IEnumerable<ReportePendienteDto>> GetAllPendientesAsync();
}
