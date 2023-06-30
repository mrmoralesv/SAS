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
                        .Include(p => p.ProductoOServicios.Where(p => p.Id == id))
                        .FirstOrDefaultAsync(p => p.Id == p.Id);
    }

    public override async Task<IEnumerable<CatalogoProdServ>> GetAllAsync()
    {
        return await _context.CatalogoProdServ
                            .Include(p => p.ProductoOServicios)
                            .ToListAsync();
    }
}
