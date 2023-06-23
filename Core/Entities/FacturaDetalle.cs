using System;
using System.Collections.Generic;

namespace Core.Entities;

public class FacturaDetalle : BaseEntity
{
    /// <summary>
    /// Identificador de la factura
    /// </summary>
    public int FacturaId { get; set; }

    /// <summary>
    /// Identificador del producto que esta validado para poder facturar,Clave Servicio o Producto
    /// </summary>
    public int ProductoValidoId { get; set; }

    /// <summary>
    /// Cantidad de servicios o productos
    /// </summary>
    public int Cantidad { get; set; }

    /// <summary>
    /// Descripcion de servicio o producto
    /// </summary>
    public string? Descripcion { get; set; }

    /// <summary>
    /// Valor unitario de servicio o producto
    /// </summary>
    public decimal ValorUnitario { get; set; }

    /// <summary>
    /// Impuestos
    /// </summary>
    public decimal Impuestos { get; set; }

    /// <summary>
    /// Notas para el administrador de los viaticos
    /// </summary>
    public string? Notas { get; set; }

    public Factura Factura { get; set; } = null!;
}
