namespace SDGP_VVP.Web.Models
{
    public class AgendaViewModel
    {
        public int IdAgenda { get; set; }

        public string Fecha { get; set; } = string.Empty;

        public string HoraInicio { get; set; } = string.Empty;

        public int CuposDisponibles { get; set; }
    }
}