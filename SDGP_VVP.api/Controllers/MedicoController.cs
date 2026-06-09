using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Infrastructure.Data;
using SDGP_VVP.Core.DTOs;

namespace SDGP_VVP.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly SDGP_VVPContext _context;

        public MedicoController(SDGP_VVPContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult ObtenerMedicos()
        {
            var medicos = _context.Medico
                .Select(m => new MedicoDTO
                {
                    IdMedico = m.IdMedico,

                    Nombre =
                        m.IdUsuarioNavigation.Nombres + " " +
                        m.IdUsuarioNavigation.Apellidos,

                    Especialidad =
                        m.IdEspecialidadNavigation.Nombre,

                    CMP = m.Cmp
                })
                .ToList();

            return Ok(medicos);
        }
    }


}