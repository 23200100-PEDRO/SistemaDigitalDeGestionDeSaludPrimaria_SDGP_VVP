using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Core.DTOs;
using SDGP_VVP.Infrastructure.Data;
using System.Security.Cryptography;
using System.Text;

namespace SDGP_VVP.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SDGP_VVPContext _context;

        public AuthController(SDGP_VVPContext context)
        {
            _context = context;
        }

        [HttpPost("registro")]
        public IActionResult Registro(RegistroPacienteDTO dto)
        {
            try
            {
                // Verificar correo existente
                if (_context.Usuario.Any(u => u.Correo == dto.Correo))
                {
                    return BadRequest("El correo ya está registrado.");
                }

                // Obtener rol Paciente
                var rolPaciente = _context.Rol
                    .FirstOrDefault(r => r.NombreRol == "Paciente");

                if (rolPaciente == null)
                {
                    return BadRequest("No existe el rol Paciente.");
                }

                // Crear Usuario
                var usuario = new Usuario
                {
                    IdRol = rolPaciente.IdRol,
                    Nombres = dto.Nombres,
                    Apellidos = dto.Apellidos,
                    Correo = dto.Correo,
                    PasswordHash = GenerarSHA256(dto.Password),
                    Estado = true,
                    FechaRegistro = DateTime.Now
                };

                _context.Usuario.Add(usuario);
                _context.SaveChanges();

                // Crear Paciente
                var paciente = new Paciente
                {
                    IdUsuario = usuario.IdUsuario,
                    Dni = dto.DNI,
                    FechaNacimiento = DateOnly.FromDateTime(dto.FechaNacimiento),
                    Sexo = dto.Sexo,
                    Direccion = dto.Direccion,
                    Telefono = dto.Telefono,
                    Seguro = "SIS",
                    EstadoSeguro = true
                };

                _context.Paciente.Add(paciente);
                _context.SaveChanges();

                // Crear Historia Clínica
                var historia = new HistoriaClinica
                {
                    IdPaciente = paciente.IdPaciente,
                    FechaCreacion = DateTime.Now
                };

                _context.HistoriaClinica.Add(historia);
                _context.SaveChanges();

                return Ok(new
                {
                    Mensaje = "Paciente registrado correctamente",
                    UsuarioId = usuario.IdUsuario,
                    PacienteId = paciente.IdPaciente,
                    HistoriaId = historia.IdHistoria
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            string passwordHash = GenerarSHA256(dto.Password);

            var usuario = _context.Usuario.FirstOrDefault(u =>
                u.Correo == dto.Correo &&
                u.PasswordHash == passwordHash);

            if (usuario == null)
            {
                return Unauthorized("Correo o contraseña incorrectos.");
            }

            return Ok(new
            {
                mensaje = "Login exitoso",
                usuario.IdUsuario,
                usuario.Nombres,
                usuario.Apellidos,
                usuario.Correo
            });
        }

        private string GenerarSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(texto));

                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}