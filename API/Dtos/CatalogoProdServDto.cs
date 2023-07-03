
namespace API.Dtos;

public class CatalogoProdServDto
{
    public int Id { get; set; }
    public string Division { get; set; } = null!;
    public string Grupo { get; set; } = null!;
    public string Clase { get; set; } = null!;

    public CatalogoProdServDto() {
        ProductoOServicios = new List<ProductoOServicioDto>();
    }
    public ICollection<ProductoOServicioDto> ProductoOServicios { get; set; }
}
