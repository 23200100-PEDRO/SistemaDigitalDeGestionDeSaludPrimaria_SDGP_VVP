using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class CitaMedica
{
    public int IdCita { get; set; }

    public int IdPaciente { get; set; }

    public int IdAgenda { get; set; }

    public DateTime FechaReserva { get; set; }

    public string Estado { get; set; } = null!;

    public string? MotivoConsulta { get; set; }

    public string TipoRegistro { get; set; } = null!;

    public virtual ConsultaMedica? ConsultaMedica { get; set; }

    public virtual AgendaMedica IdAgendaNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
