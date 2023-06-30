using Core.Entities;

namespace API.Dtos;

public class CatalogoProdServDto
{
    public string Division { get; set; } = null!;
    public string Grupo { get; set; } = null!;
    public string Clase { get; set; } = null!;

    public CatalogoProdServDto() {
        productoOServicios = new List<ProductoOServicioDto>();
    }
    public ICollection<ProductoOServicioDto> productoOServicios { get; set; }
}
