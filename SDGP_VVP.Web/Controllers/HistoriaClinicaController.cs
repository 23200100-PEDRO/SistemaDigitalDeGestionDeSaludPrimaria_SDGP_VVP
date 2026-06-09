using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Web.Models;
using System.Text.Json;

namespace SDGP_VVP.Web.Controllers
{
    public class HistoriaClinicaController : Controller
    {
        private readonly HttpClient _httpClient;

        public HistoriaClinicaController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var modelo = new HistoriaClinicaCompletaViewModel();

            // Historia
            var responseHistoria = await _httpClient.GetAsync(
                "http://localhost:5251/api/Paciente/historia/1");

            if (responseHistoria.IsSuccessStatusCode)
            {
                var jsonHistoria =
                    await responseHistoria.Content.ReadAsStringAsync();

                modelo.Historia =
                    JsonSerializer.Deserialize<HistoriaClinicaViewModel>
                    (
                        jsonHistoria,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    ) ?? new HistoriaClinicaViewModel();
            }

            // Consultas
            var responseDetalle = await _httpClient.GetAsync(
                "http://localhost:5251/api/Paciente/historia/detalle/1");

            if (responseDetalle.IsSuccessStatusCode)
            {
                var jsonDetalle =
                    await responseDetalle.Content.ReadAsStringAsync();

                modelo.Consultas =
                    JsonSerializer.Deserialize
                    <List<HistoriaDetalleViewModel>>
                    (
                        jsonDetalle,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    ) ?? new List<HistoriaDetalleViewModel>();
            }

            return View(modelo);
        }
    }
}