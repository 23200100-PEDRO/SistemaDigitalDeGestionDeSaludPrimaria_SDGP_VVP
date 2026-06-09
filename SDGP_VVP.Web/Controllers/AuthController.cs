using Microsoft.AspNetCore.Mvc;
using SDGP_VVP.Web.Models;
using System.Text;
using System.Text.Json;

namespace SDGP_VVP.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(
            LoginViewModel model)
        {
            var dto = new LoginDTO
            {
                Correo = model.Correo,
                Password = model.Password
            };

            var json = JsonSerializer.Serialize(dto);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(
                "http://localhost:5251/api/Auth/login",
                content);

            if (response.IsSuccessStatusCode)
            {
                HttpContext.Session.SetString(
    "Usuario",
    model.Correo);

                var jsonResponse =
                    await response.Content.ReadAsStringAsync();

                using JsonDocument doc =
                    JsonDocument.Parse(jsonResponse);

                HttpContext.Session.SetString(
                    "Nombre",
                    doc.RootElement
                       .GetProperty("nombres")
                       .GetString() ?? "");

                HttpContext.Session.SetString(
                    "Apellidos",
                    doc.RootElement
                       .GetProperty("apellidos")
                       .GetString() ?? "");

                return RedirectToAction(
                    "Index",
                    "Dashboard");
            }

            ViewBag.Error =
                "Correo o contraseña incorrectos";

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(
                "Index",
                "Home");
        }
    }
}