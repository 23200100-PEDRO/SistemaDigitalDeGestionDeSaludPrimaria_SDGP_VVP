using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Web.Models;
using System.Text.Json;

namespace SDGP_VVP.Web.Controllers
{
    public class MedicoController : Controller
    {
        private readonly HttpClient _httpClient;

        public MedicoController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(
                "http://localhost:5251/api/Medico");

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<MedicoViewModel>());
            }

            var json = await response.Content.ReadAsStringAsync();

            var medicos =
                JsonSerializer.Deserialize<List<MedicoViewModel>>
                (
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

            return View(medicos);
        }
    }
}