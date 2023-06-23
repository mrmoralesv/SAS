using System;
using System.Collections.Generic;

namespace Core.Entities;

public class CatalogoProducto : BaseEntity
{
    /// <summary>
    /// Identificador de la clase de los productos
    /// </summary>
    //public int CatalogoProductoId { get; set; }

    /// <summary>
    /// Nombre de la Division
    /// </summary>
    public string Division { get; set; } = null!;

    /// <summary>
    /// grupo de la Division
    /// </summary>
    public string Grupo { get; set; } = null!;

    /// <summary>
    /// Clase de la Division
    /// </summary>
    public string Clase { get; set; } = null!;
}
