using System;
using System.Collections.Generic;

namespace Core.Entities;

public class SaldoDetalle : BaseEntity
{
    /// <summary>
    /// Identificador del aumento o disminucion de saldo
    /// </summary>
    public int SaldoId { get; set; }

    /// <summary>
    /// Aumentos y disminuciones de saldo
    /// </summary>
    public decimal? SaldoAD { get; set; }

    /// <summary>
    /// Descripcion del aumento o disminucion de saldo
    /// </summary>
    public string Descripcion { get; set; }

    public Saldo Saldo { get; set; } = null!;
}
