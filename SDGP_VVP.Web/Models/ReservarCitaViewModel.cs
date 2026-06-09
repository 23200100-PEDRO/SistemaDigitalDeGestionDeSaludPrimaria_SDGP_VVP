namespace SDGP_VVP.Web.Models
{
    public class ReservarCitaViewModel
    {
        public int IdPaciente { get; set; }

        public int IdAgenda { get; set; }

        public int IdEspecialidad { get; set; }

        public int IdMedico { get; set; }

        public string MotivoConsulta { get; set; } = string.Empty;
    }
}