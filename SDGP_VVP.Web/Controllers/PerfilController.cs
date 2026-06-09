using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Web.Models;
using System.Text.Json;

namespace SDGP_VVP.Web.Controllers
{
    public class PerfilController : Controller
    {
        private readonly HttpClient _httpClient;

        public PerfilController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(
                "http://localhost:5251/api/Paciente/perfil/1");

            if (!response.IsSuccessStatusCode)
            {
                return View(new PerfilViewModel());
            }

            var json = await response.Content.ReadAsStringAsync();

            var perfil =
                JsonSerializer.Deserialize<PerfilViewModel>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(perfil);
        }
    }
}