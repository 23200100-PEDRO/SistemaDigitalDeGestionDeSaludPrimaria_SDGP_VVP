using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Core.DTOs;
using SDGP_VVP.Infrastructure.Data;

namespace SDGP_VVP.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly SDGP_VVPContext _context;

        public DashboardController(SDGP_VVPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ObtenerEstadisticas()
        {
            var datos = new DashboardDTO
            {
                TotalCitas =
                    _context.CitaMedica.Count(),

                CitasReservadas =
                    _context.CitaMedica.Count(
                        c => c.Estado == "Reservada"),

                CitasCanceladas =
                    _context.CitaMedica.Count(
                        c => c.Estado == "Cancelada"),

                TotalMedicos =
                    _context.Medico.Count(),

                TotalHistorias =
                    _context.HistoriaClinica.Count()
            };

            return Ok(datos);
        }
    }
}