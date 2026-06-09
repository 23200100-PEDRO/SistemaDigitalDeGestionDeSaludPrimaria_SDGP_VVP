namespace SDGP_VVP.Web.Models
{
    public class MedicoViewModel
    {
        public int IdMedico { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        public string CMP { get; set; } = string.Empty;
    }
}