using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class Triage
{
    public int IdTriage { get; set; }

    public int IdPaciente { get; set; }

    public int IdEnfermero { get; set; }

    public string? Prioridad { get; set; }

    public string? MotivoConsulta { get; set; }

    public DateTime FechaHora { get; set; }

    public virtual Enfermero IdEnfermeroNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
