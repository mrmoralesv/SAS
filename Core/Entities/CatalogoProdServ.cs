using System;
using System.Collections.Generic;

namespace Core.Entities;

public class CatalogoProdServ : BaseEntity
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

    public CatalogoProdServ()
    {
        ProductoOServicios = new List<ProductoOServicio>();
    }
    public ICollection<ProductoOServicio> ProductoOServicios { get; set; }

}
