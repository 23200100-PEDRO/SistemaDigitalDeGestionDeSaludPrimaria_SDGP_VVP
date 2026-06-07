using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class Admision
{
    public int IdAdmision { get; set; }

    public int IdUsuario { get; set; }

    public string? CodigoEmpleado { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
