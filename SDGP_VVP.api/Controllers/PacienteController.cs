using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Core.DTOs;
using SDGP_VVP.Infrastructure.Data;

namespace SDGP_VVP.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly SDGP_VVPContext _context;

        public PacienteController(SDGP_VVPContext context)
        {
            _context = context;
        }

        [HttpGet("perfil/{idPaciente}")]
        public IActionResult ObtenerPerfil(int idPaciente)
        {
            var paciente = _context.Paciente
                .FirstOrDefault(p => p.IdPaciente == idPaciente);

            if (paciente == null)
            {
                return NotFound();
            }

            var usuario = _context.Usuario
                .FirstOrDefault(u => u.IdUsuario == paciente.IdUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(new PerfilPacienteDTO
            {
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                Dni = paciente.Dni,
                Correo = usuario.Correo,
                Telefono = paciente.Telefono,
                Direccion = paciente.Direccion,
                Seguro = paciente.Seguro
            });
        }

        [HttpGet("historia/{idPaciente}")]
        public IActionResult ObtenerHistoria(int idPaciente)
        {
            var historia = _context.HistoriaClinica
                .FirstOrDefault(h => h.IdPaciente == idPaciente);

            if (historia == null)
            {
                return NotFound();
            }

            return Ok(new HistoriaClinicaDTO
            {
                IdHistoria = historia.IdHistoria,
                FechaCreacion = historia.FechaCreacion,
                IdPaciente = historia.IdPaciente
            });
        }

        [HttpGet("historia/detalle/{idPaciente}")]
        public IActionResult ObtenerDetalleHistoria(int idPaciente)
        {
            var historia = _context.HistoriaClinica
                .FirstOrDefault(h => h.IdPaciente == idPaciente);

            if (historia == null)
            {
                return NotFound();
            }

            var consultas = _context.ConsultaMedica
                .Where(c => c.IdHistoria == historia.IdHistoria)
                .Select(c => new HistoriaDetalleDTO
                {
                    Fecha = c.Fecha,

                    Medico =
                        c.IdMedicoNavigation.IdUsuarioNavigation.Nombres
                        + " " +
                        c.IdMedicoNavigation.IdUsuarioNavigation.Apellidos,

                    Diagnostico =
                        c.Diagnostico
                         .Select(d => d.Descripcion)
                         .FirstOrDefault() ?? "",

                    Observaciones = c.Observaciones
                })
                .ToList();

            return Ok(consultas);
        }
    }
}