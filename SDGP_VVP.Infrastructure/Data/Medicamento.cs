using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class Medicamento
{
    public int IdMedicamento { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Concentracion { get; set; }

    public string? Presentacion { get; set; }

    public int Stock { get; set; }

    public int StockMinimo { get; set; }

    public virtual ICollection<DetalleReceta> DetalleReceta { get; set; } = new List<DetalleReceta>();
}
