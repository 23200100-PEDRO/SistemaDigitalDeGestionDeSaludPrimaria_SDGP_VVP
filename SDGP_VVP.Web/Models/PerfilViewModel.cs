namespace SDGP_VVP.Web.Models
{
    public class PerfilViewModel
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