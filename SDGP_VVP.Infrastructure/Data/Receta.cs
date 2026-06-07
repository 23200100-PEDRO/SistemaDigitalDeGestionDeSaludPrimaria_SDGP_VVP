using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class Receta
{
    public int IdReceta { get; set; }

    public int IdConsulta { get; set; }

    public DateTime FechaEmision { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<DetalleReceta> DetalleReceta { get; set; } = new List<DetalleReceta>();

    public virtual ConsultaMedica IdConsultaNavigation { get; set; } = null!;
}
