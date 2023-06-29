namespace API.Dtos;
public class ReporteGastoDto
{
    public ReporteGastoDto()
    {
        Facturas = new List<FacturaDto>();
    }
    public int Id { get; set; }
    public int ViaticoId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool Estatus { get; set; }
    public DateTime FechaInsert { get; set; }

    public ICollection<FacturaDto> Facturas { get; set; }
}
