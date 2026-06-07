using System;
using System.Collections.Generic;

namespace SDGP_VVP.Infrastructure.Data;

public partial class ConsultaMedica
{
    public int IdConsulta { get; set; }

    public int IdHistoria { get; set; }

    public int IdMedico { get; set; }

    public int IdCita { get; set; }

    public DateTime Fecha { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<Diagnostico> Diagnostico { get; set; } = new List<Diagnostico>();

    public virtual CitaMedica IdCitaNavigation { get; set; } = null!;

    public virtual HistoriaClinica IdHistoriaNavigation { get; set; } = null!;

    public virtual Medico IdMedicoNavigation { get; set; } = null!;

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
