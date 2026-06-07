namespace SDGP_VVP.Core.DTOs;

public class ReservarCitaDTO
{
    public int IdPaciente { get; set; }

    public int IdAgenda { get; set; }

    public string MotivoConsulta { get; set; } = string.Empty;
}