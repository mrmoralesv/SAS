using Core.Entities;

namespace API.Dtos;

public class FacturaDetalleDto
{
    public int FacturaId { get; set; }
    public int ProductoValidoId { get; set; }
    public int Cantidad { get; set; }
    public string Descripcion { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal Impuestos { get; set; }
    public string Notas { get; set; }
}
