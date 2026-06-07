using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class Especialidad
{
    public int IdEspecialidad { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Medico> Medico { get; set; } = new List<Medico>();
}
