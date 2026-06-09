namespace SDGP_VVP.Web.Models
{
    public class HistoriaDetalleViewModel
    {
        public DateTime Fecha { get; set; }

        public string Medico { get; set; } = string.Empty;

        public string Diagnostico { get; set; } = string.Empty;

        public string? Observaciones { get; set; }
    }
}