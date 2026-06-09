namespace SDGP_VVP.Core.DTOs
{
    public class MedicoDTO
    {
        public int IdMedico { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        public string CMP { get; set; } = string.Empty;
    }
}