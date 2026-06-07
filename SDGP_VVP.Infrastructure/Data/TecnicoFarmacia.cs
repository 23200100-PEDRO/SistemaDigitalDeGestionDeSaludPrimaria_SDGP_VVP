using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class TecnicoFarmacia
{
    public int IdFarmacia { get; set; }

    public int IdUsuario { get; set; }

    public string? CodigoFarmacia { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
