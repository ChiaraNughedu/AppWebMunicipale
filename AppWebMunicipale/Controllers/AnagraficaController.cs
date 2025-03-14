using AppWebMunicipale.Models;
using AppWebMunicipale.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppWebMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaService _anagraficaService;

        public AnagraficaController(AnagraficaService anagraficaService)
        {
            _anagraficaService = anagraficaService;
        }

        public async Task<IActionResult> Index()
        {
            var anagrafiche = await _anagraficaService.GetAllAsync();
            return View(anagrafiche);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _anagraficaService.GetByIdAsync(id.Value);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                await _anagraficaService.CreateAsync(anagrafica);
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _anagraficaService.GetByIdAsync(id.Value);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _anagraficaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
