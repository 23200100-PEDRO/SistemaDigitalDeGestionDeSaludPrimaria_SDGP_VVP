using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class Auditoria
{
    public int IdAuditoria { get; set; }

    public int IdUsuario { get; set; }

    public string Accion { get; set; } = null!;

    public DateTime FechaHora { get; set; }

    public string? Detalle { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
