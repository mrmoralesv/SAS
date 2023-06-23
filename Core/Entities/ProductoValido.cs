using System;
using System.Collections.Generic;

namespace Core.Entities;

public class ProductoValido : BaseEntity
{
    /// <summary>
    /// Identificador del producto que esta validado para poder facturar,Clave Servicio o Producto
    /// </summary>
    //public int ProductoValidoId { get; set; }

    /// <summary>
    /// Identificador para clasificacion del producto
    /// </summary>
    public int CatalogoProductoId { get; set; }

    /// <summary>
    /// Descripcion del producto
    /// </summary>
    public string NombreProducto { get; set; } = null!;

    /// <summary>
    /// 0= Producto no valido para SINCI 1=Producto valido para SINCI
    /// </summary>
    public bool? Estatus { get; set; }

    /// <summary>
    /// Fecha en que se inserto el producto
    /// </summary>
    public DateTime? FechaInsert { get; set; }
}
