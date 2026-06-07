namespace SDGP_VVP.Core.DTOs;

public class RegistroPacienteDTO
{
    public string Nombres { get; set; } = string.Empty;

    public string Apellidos { get; set; } = string.Empty;

    public string Correo { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string DNI { get; set; } = string.Empty;

    public DateTime FechaNacimiento { get; set; }

    public string Sexo { get; set; } = string.Empty;

    public string Direccion { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;
}