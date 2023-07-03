using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CatalogoProdServRepository : GenericRepository<CatalogoProdServ>, ICatalogoProdServRepository
{
    public CatalogoProdServRepository(SASContext context) : base(context)
    {
    }

    public override async Task<CatalogoProdServ> GetByIdAsync(int id)
    {
        return await _context.CatalogoProdServ
                        .Include(p => p.ProductoOServicios)
                        .FirstOrDefaultAsync(p => p.Id == id);

        //var ProducServicio = await _context.CatalogoProdServ
        //                .Join(_context.ProductoOServicio, c => c.Id, p => p.CatalogoProdServId, (c, p) => new { c, p })
        //                .FirstOrDefaultAsync(x => x.p.Id == id);

        //var ProducServicio = await _context.CatalogoProdServ
        //                .Include(p => p.ProductoOServicios.Where(p => p.Id == id))
        //                .FirstOrDefaultAsync();

        //if (ProducServicio.ProductoOServicios.Count() == 0)
        //    ProducServicio = null;

        //return ProducServicio;
    }

    public override async Task<IEnumerable<CatalogoProdServ>> GetAllAsync()
    {
        return await _context.CatalogoProdServ
                            .Include(p => p.ProductoOServicios)
                            .ToListAsync();
    }
}
