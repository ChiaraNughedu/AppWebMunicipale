using AppWebMunicipale.Models;
using AppWebMunicipale.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AppWebMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleService _verbaleService;
        private readonly AnagraficaService _anagraficaService;
        private readonly TipoViolazioneService _violazioneService;

        public VerbaleController(VerbaleService verbaleService, AnagraficaService anagraficaService, TipoViolazioneService violazioneService)
        {
            _verbaleService = verbaleService;
            _anagraficaService = anagraficaService;
            _violazioneService = violazioneService;
        }

        // Azione per visualizzare il form di creazione
        public async Task<IActionResult> Create()
        {
            // Recupera le liste di anagrafica e violazione
            var anagraficaList = await _anagraficaService.GetAllAsync();
            var violazioneList = await _violazioneService.GetAllAsync();

            // Verifica se le liste sono vuote o nulle
            if (anagraficaList == null || !anagraficaList.Any())
            {
                ModelState.AddModelError("", "Errore: non ci sono anagrafiche disponibili.");
            }

            if (violazioneList == null || !violazioneList.Any())
            {
                ModelState.AddModelError("", "Errore: non ci sono tipi di violazione disponibili.");
            }

            // Popola le SelectList per le dropdown
            ViewData["IdAnagrafica"] = new SelectList(anagraficaList, "IdAnagrafica", "NomeCompleto");
            ViewData["IdViolazione"] = new SelectList(violazioneList, "IdViolazione", "Descrizione");

            return View();
        }

        // Azione per gestire il salvataggio del verbale
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                // Aggiungi il nuovo verbale al contesto tramite il servizio
                await _verbaleService.CreateAsync(verbale);

                // Redirect dopo il salvataggio, puoi anche visualizzare una vista di conferma
                return RedirectToAction("Index");  // O alla lista dei verbali
            }

            // Se ci sono errori nel form, torna al form con gli errori
            return View(verbale);
        }

        // Metodo Index per visualizzare la lista dei verbali
        public async Task<IActionResult> Index()
        {
            var verbali = await _verbaleService.GetAllAsync();
            return View(verbali);
        }
    }
}
