using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class SignosVitales
{
    public int IdSignos { get; set; }

    public int IdPaciente { get; set; }

    public int IdEnfermero { get; set; }

    public string? PresionArterial { get; set; }

    public decimal? Peso { get; set; }

    public decimal? Talla { get; set; }

    public decimal? Temperatura { get; set; }

    public decimal? SaturacionOxigeno { get; set; }

    public int? FrecuenciaCardiaca { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Enfermero IdEnfermeroNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
