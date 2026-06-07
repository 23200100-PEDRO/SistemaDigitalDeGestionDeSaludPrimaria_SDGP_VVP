using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class Diagnostico
{
    public int IdDiagnostico { get; set; }

    public int IdConsulta { get; set; }

    public string? CodigoCie10 { get; set; }

    public string? Descripcion { get; set; }

    public virtual ConsultaMedica IdConsultaNavigation { get; set; } = null!;
}
