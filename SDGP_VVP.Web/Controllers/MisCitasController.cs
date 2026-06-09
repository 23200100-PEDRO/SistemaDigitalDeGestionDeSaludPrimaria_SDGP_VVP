using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Web.Models;
using System.Text.Json;

namespace SDGP_VVP.Web.Controllers
{
    public class MisCitasController : Controller
    {
        private readonly HttpClient _httpClient;

        public MisCitasController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(
                "http://localhost:5251/api/Cita/miscitas/1");

            var json = await response.Content.ReadAsStringAsync();

            ViewBag.Status = response.StatusCode;
            ViewBag.Json = json;

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<MisCitaViewModel>());
            }

            var citas = JsonSerializer.Deserialize<List<MisCitaViewModel>>
            (
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );

            return View(citas);
        }

        [HttpPost]
        public async Task<IActionResult> Cancelar(int id)
        {
            await _httpClient.PutAsync(
                $"http://localhost:5251/api/Cita/cancelar/{id}",
                null);

            return RedirectToAction("Index");
        }
    }
}