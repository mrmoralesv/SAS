using System;
using System.Collections.Generic;

namespace Core.Entities;

public class Saldo : BaseEntity
{
    /// <summary>
    /// Identificador para cada uno de los aumentos o disminuciones de saldo
    /// </summary>
    //public int SaldoId { get; set; }

    /// <summary>
    /// Identificador personal del trabajador
    /// </summary>
    public int PersonalId { get; set; }

    /// <summary>
    /// Aumentos y disminuciones de saldo
    /// </summary>
    public decimal? SaldoAD { get; set; }

    public string Descripcion { get; set; }
}
