
using Core.Entities;

namespace API.Dtos;

public class FacturaDto
{
    public int Id { get; set; }
    public int ReportegastoId { get; set; }
    public bool Estatus { get; set; }
    public string RfCEmisor { get; set; } 
    public string RfCReceptor { get; set; } 
    public decimal Total { get; set; }
    public string UUID { get; set; } 
    public string SelloSat { get; set; } 
    public DateTime FechaTimbrado { get; set; }
    public DateTime FechaInsert { get; set; }

    public FacturaDto()
    {
        FacturaDetalles = new List<FacturaDetalleDto>();
    }

    public ICollection<FacturaDetalleDto> FacturaDetalles { get; set; }

}
