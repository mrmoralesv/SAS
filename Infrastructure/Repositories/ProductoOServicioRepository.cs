using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductoOServicioRepository : GenericRepository<ProductoOServicio>, IProductoOServicioRepository
{
    public ProductoOServicioRepository(SASContext context) : base(context)
    {
    }

    public override async Task<ProductoOServicio> GetByIdAsync(int id)
    {
        return await _context.ProductoOServicio
                        .Include(p => p.CatalogoProdServ)
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

    public override async Task<IEnumerable<ProductoOServicio>> GetAllAsync()
    {
        return await _context.ProductoOServicio
                            .Include(p => p.CatalogoProdServ)
                            .ToListAsync();
    }
}
