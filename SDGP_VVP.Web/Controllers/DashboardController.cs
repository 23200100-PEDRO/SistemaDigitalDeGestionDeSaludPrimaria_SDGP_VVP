using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Web.Models;
using System.Text.Json;

namespace SDGP_VVP.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HttpClient _httpClient;

        public DashboardController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction(
                    "Login",
                    "Auth");
            }

            var response = await _httpClient.GetAsync(
                "http://localhost:5251/api/Dashboard");

            if (!response.IsSuccessStatusCode)
            {
                return View(new DashboardViewModel());
            }

            var json = await response.Content.ReadAsStringAsync();

            var dashboard =
                JsonSerializer.Deserialize<DashboardViewModel>
                (
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            ViewBag.Nombre =
            HttpContext.Session.GetString("Nombre");

            ViewBag.Apellidos =
                HttpContext.Session.GetString("Apellidos");
            return View(dashboard);
        }
    }
}