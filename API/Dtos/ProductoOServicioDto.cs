using Core.Entities;

namespace API.Dtos;

public class ProductoOServicioDto
{
    public int Id { get; set; }
    public int CatalogoProdServId { get; set; }
    public string NombreProducto { get; set; } = null!;
    public bool? Estatus { get; set; }
    public DateTime? FechaInsert { get; set; }


}
