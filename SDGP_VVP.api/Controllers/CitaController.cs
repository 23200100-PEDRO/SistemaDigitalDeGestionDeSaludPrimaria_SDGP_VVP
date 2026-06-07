using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Core.DTOs;
using SDGP_VVP.Infrastructure.Data;
// Cambio de prueba para GitHub 2026    
namespace SDGP_VVP.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly SDGP_VVPContext _context;

        public CitaController(SDGP_VVPContext context)
        {
            _context = context;
        }

        [HttpGet("especialidades")]
        public IActionResult ObtenerEspecialidades()
        {
            var especialidades = _context.Especialidad
                .Select(e => new
                {
                    e.IdEspecialidad,
                    e.Nombre
                })
                .ToList();

            return Ok(especialidades);
        }

        [HttpGet("medicos/{idEspecialidad}")]
        public IActionResult ObtenerMedicos(int idEspecialidad)
        {
            var medicos = _context.Medico
                .Where(m => m.IdEspecialidad == idEspecialidad)
                .Select(m => new
                {
                    m.IdMedico,
                    Nombre = m.IdUsuarioNavigation.Nombres + " " +
                             m.IdUsuarioNavigation.Apellidos,
                    m.Cmp
                })
                .ToList();

            return Ok(medicos);
        }

        [HttpGet("agendas/{idMedico}")]
        public IActionResult ObtenerAgendas(int idMedico)
        {
            var agendas = _context.AgendaMedica
                .Where(a => a.IdMedico == idMedico &&
                            a.Estado == true &&
                            a.CuposDisponibles > 0)
                .Select(a => new
                {
                    a.IdAgenda,
                    a.Fecha,
                    a.HoraInicio,
                    a.HoraFin,
                    a.CuposDisponibles
                })
                .ToList();

            return Ok(agendas);
        }

        [HttpPost("reservar")]
        public IActionResult ReservarCita(ReservarCitaDTO dto)
        {
            var agenda = _context.AgendaMedica
                .FirstOrDefault(a => a.IdAgenda == dto.IdAgenda);

            if (agenda == null)
            {
                return BadRequest("Agenda no encontrada.");
            }

            if (agenda.CuposDisponibles <= 0)
            {
                return BadRequest("No hay cupos disponibles.");
            }

            var cita = new CitaMedica
            {
                IdPaciente = dto.IdPaciente,
                IdAgenda = dto.IdAgenda,
                FechaReserva = DateTime.Now,
                Estado = "Reservada",
                MotivoConsulta = dto.MotivoConsulta,
                TipoRegistro = "Online"
            };

            _context.CitaMedica.Add(cita);

            agenda.CuposDisponibles--;

            _context.SaveChanges();

            return Ok(new
            {
                Mensaje = "Cita reservada correctamente",
                cita.IdCita
            });
        }

        [HttpGet("miscitas/{idPaciente}")]
        public IActionResult MisCitas(int idPaciente)
        {
            var citas = _context.CitaMedica
                .Where(c => c.IdPaciente == idPaciente)
                .Select(c => new
                {
                    c.IdCita,

                    Especialidad =
                        c.IdAgendaNavigation
                         .IdMedicoNavigation
                         .IdEspecialidadNavigation
                         .Nombre,

                    Medico =
                        c.IdAgendaNavigation
                         .IdMedicoNavigation
                         .IdUsuarioNavigation
                         .Nombres
                         + " " +
                        c.IdAgendaNavigation
                         .IdMedicoNavigation
                         .IdUsuarioNavigation
                         .Apellidos,

                    Fecha =
                        c.IdAgendaNavigation.Fecha,

                    HoraInicio =
                        c.IdAgendaNavigation.HoraInicio,

                    Estado =
                        c.Estado,

                    Motivo =
                        c.MotivoConsulta
                })
                .ToList();

            return Ok(citas);
        }
    }
}
