namespace SDGP_VVP.Web.Models
{
    public class MisCitaViewModel
    {
        public int IdCita { get; set; }

        public string Especialidad { get; set; } = string.Empty;

        public string Medico { get; set; } = string.Empty;

        public string Fecha { get; set; } = string.Empty;

        public string HoraInicio { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string Motivo { get; set; } = string.Empty;
    }
}