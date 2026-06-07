using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class Enfermero
{
    public int IdEnfermero { get; set; }

    public int IdUsuario { get; set; }

    public string? CodigoEnfermero { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<SignosVitales> SignosVitales { get; set; } = new List<SignosVitales>();

    public virtual ICollection<Triage> Triage { get; set; } = new List<Triage>();
}
