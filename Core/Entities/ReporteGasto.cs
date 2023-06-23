using System;
using System.Collections.Generic;

namespace Core.Entities;

public class ReporteGasto : BaseEntity
{
    /// <summary>
    /// Identificador para los cada uno de los reportes de gastos
    /// </summary>
    //public int ReporteGastoId { get; set; }

    /// <summary>
    /// Idetificador para cada uno de los viaticos
    /// </summary>
    public int ViaticoId { get; set; }

    /// <summary>
    /// Fecha inicio del reporte de gastos
    /// </summary>
    public DateTime FechaInicio { get; set; }

    /// <summary>
    /// Fecha fin del reporte de gastos
    /// </summary>
    public DateTime FechaFin { get; set; }

    /// <summary>
    /// 0=No validado 1=Validado
    /// </summary>
    public bool? Estatus { get; set; }

    /// <summary>
    /// Fecha en que se genero el reporte de gastos
    /// </summary>
    public DateTime? FechaInsert { get; set; }

    public ReporteGasto()
    {
        Facturas = new List<Factura>();
    }
    public ICollection<Factura> Facturas { get; set; }
}
