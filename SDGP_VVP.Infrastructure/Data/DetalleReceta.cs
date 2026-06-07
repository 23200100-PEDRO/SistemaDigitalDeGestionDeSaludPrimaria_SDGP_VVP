using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class DetalleReceta
{
    public int IdDetalle { get; set; }

    public int IdReceta { get; set; }

    public int IdMedicamento { get; set; }

    public int Cantidad { get; set; }

    public string? Dosis { get; set; }

    public string? Frecuencia { get; set; }

    public string? Duracion { get; set; }

    public virtual Medicamento IdMedicamentoNavigation { get; set; } = null!;

    public virtual Receta IdRecetaNavigation { get; set; } = null!;
}
