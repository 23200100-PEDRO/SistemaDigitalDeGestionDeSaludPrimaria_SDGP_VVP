using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public int IdUsuario { get; set; }

    public string Dni { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Seguro { get; set; }

    public bool? EstadoSeguro { get; set; }

    public virtual ICollection<CitaMedica> CitaMedica { get; set; } = new List<CitaMedica>();

    public virtual HistoriaClinica? HistoriaClinica { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<SignosVitales> SignosVitales { get; set; } = new List<SignosVitales>();

    public virtual ICollection<Triage> Triage { get; set; } = new List<Triage>();
}
