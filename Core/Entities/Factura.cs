using System;
using System.Collections.Generic;

namespace Core.Entities;

public class Factura : BaseEntity
{
    /// <summary>
    /// Identificador de la factura
    /// </summary>
    //public int FacturaId { get; set; }

    /// <summary>
    /// Identificador del reporte de gastos al que pertenece la factura
    /// </summary>
    public int ReporteGastoId { get; set; }

    /// <summary>
    /// 0=Factura cancelada, 1=Factura autorizada
    /// </summary>
    public bool? Estatus { get; set; }

    /// <summary>
    /// RFC del emisor de la factura
    /// </summary>
    public string RfCEmisor { get; set; } = null!;

    /// <summary>
    /// RFC del receptor de la factura
    /// </summary>
    public string RfCReceptor { get; set; } = null!;

    /// <summary>
    /// Monto total de la factura
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// UUID de la factura
    /// </summary>
    public string UUID { get; set; } = null!;

    /// <summary>
    /// Sello digital de emisor
    /// </summary>
    public string SelloSat { get; set; } = null!;

    /// <summary>
    /// Fecha del timbrado de la factura
    /// </summary>
    public DateTime FechaTimbrado { get; set; }

    /// <summary>
    /// Fecha de la insercion de la factura
    /// </summary>
    public DateTime? FechaInsert { get; set; }

    /// <summary>
    /// XML de la factura
    /// </summary>
    public string XmlFactura { get; set; }

    public ReporteGasto ReporteGasto { get; set; }

    public Factura()
    {
        FacturaDetalles = new List<FacturaDetalle>();
    }
    public ICollection<FacturaDetalle> FacturaDetalles { get; set; }

}
