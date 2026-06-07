using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class HistoriaClinica
{
    public int IdHistoria { get; set; }

    public int IdPaciente { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<ConsultaMedica> ConsultaMedica { get; set; } = new List<ConsultaMedica>();

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
