using AppWebMunicipale.Models;
using AppWebMunicipale.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppWebMunicipale.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly TipoViolazioneService _service;

        public TipoViolazioneController(TipoViolazioneService service)
        {
            _service = service;
        }

        // GET: TipoViolazione
        public async Task<IActionResult> Index()
        {
            // Chiamata al servizio per ottenere tutte le violazioni
            var tipoViolazioni = await _service.GetAllAsync();
            return View(tipoViolazioni); // Passiamo i dati alla view
        }
    }
}
