namespace SDGP_VVP.Core.DTOs
{
    public class HistoriaDetalleDTO
    {
        public DateTime Fecha { get; set; }

        public string Medico { get; set; } = string.Empty;

        public string Diagnostico { get; set; } = string.Empty;

        public string? Observaciones { get; set; }
    }
}