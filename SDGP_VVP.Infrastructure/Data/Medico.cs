using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class Medico
{
    public int IdMedico { get; set; }

    public int IdUsuario { get; set; }

    public int IdEspecialidad { get; set; }

    public string Cmp { get; set; } = null!;

    public virtual ICollection<AgendaMedica> AgendaMedica { get; set; } = new List<AgendaMedica>();

    public virtual ICollection<ConsultaMedica> ConsultaMedica { get; set; } = new List<ConsultaMedica>();

    public virtual Especialidad IdEspecialidadNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
