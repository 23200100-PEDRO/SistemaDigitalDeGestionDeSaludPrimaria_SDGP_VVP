using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class AgendaMedica
{
    public int IdAgenda { get; set; }

    public int IdMedico { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public int CuposDisponibles { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<CitaMedica> CitaMedica { get; set; } = new List<CitaMedica>();

    public virtual Medico IdMedicoNavigation { get; set; } = null!;
}
