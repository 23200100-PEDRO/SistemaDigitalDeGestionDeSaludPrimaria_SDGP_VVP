namespace SDGP_VVP.Core.DTOs
{
    public class PerfilPacienteDTO
    {
        public string Nombres { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public string Dni { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string? Seguro { get; set; }
    }
}