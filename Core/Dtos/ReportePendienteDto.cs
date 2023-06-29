using Core.Entities;

namespace Core.Dtos;

public class ReportePendienteDto : BaseEntity
{
    public int Id_personal { get; set; }
    public int Id_proyecto { get; set; }
    public int Dias { get; set; }
    public string Ciudad { get; set; }
    public decimal Total { get; set; }
    public string Descripcion { get; set; }
    public string Nombre { get; set; }
}
