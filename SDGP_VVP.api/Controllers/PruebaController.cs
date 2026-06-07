using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Infrastructure.Data;

namespace SDGP_VVP.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly SDGP_VVPContext _context;

        public PruebaController(SDGP_VVPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ObtenerRoles()
        {
            var roles = _context.Rol.ToList();

            return Ok(roles);
        }
    }
}