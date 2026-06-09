using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Web.Models;
using System.Text;
using System.Text.Json;


namespace SDGP_VVP.Web.Controllers
{
    public class CitaController : Controller
    {
        private readonly HttpClient _httpClient;

        public CitaController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Reservar()
        {
            ViewBag.Especialidades =
                await ObtenerEspecialidades();

            ViewBag.Medicos =
                await ObtenerMedicos(1);

            ViewBag.Agendas =
                await ObtenerAgendas(1);

            return View(
                new ReservarCitaViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Reservar(
            ReservarCitaViewModel model)
        {
            model.IdPaciente = 1;

            var json = JsonSerializer.Serialize(model);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(
                "http://localhost:5251/api/Cita/reservar",
                content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] =
                    "Cita reservada correctamente";

                return RedirectToAction(
                    "Index",
                    "MisCitas");
            }

            ViewBag.Error =
                await response.Content.ReadAsStringAsync();

            return View(model);
        }

        private async Task<List<EspecialidadViewModel>>
            ObtenerEspecialidades()
        {
            var response = await _httpClient.GetAsync(
                "http://localhost:5251/api/Cita/especialidades");

            if (!response.IsSuccessStatusCode)
            {
                return new List<EspecialidadViewModel>();
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize
                <List<EspecialidadViewModel>>
                (
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                ) ?? new List<EspecialidadViewModel>();
        }

        private async Task<List<MedicoViewModel>>
            ObtenerMedicos(int idEspecialidad)
        {
            var response = await _httpClient.GetAsync(
                $"http://localhost:5251/api/Cita/medicos/{idEspecialidad}");

            if (!response.IsSuccessStatusCode)
            {
                return new List<MedicoViewModel>();
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<MedicoViewModel>>
            (
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            ) ?? new List<MedicoViewModel>();
        }

        private async Task<List<AgendaViewModel>>
        ObtenerAgendas(int idMedico)
        {
            var response = await _httpClient.GetAsync(
                $"http://localhost:5251/api/Cita/agendas/{idMedico}");

            if (!response.IsSuccessStatusCode)
            {
                return new List<AgendaViewModel>();
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<AgendaViewModel>>
            (
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            ) ?? new List<AgendaViewModel>();
        }
    }
}