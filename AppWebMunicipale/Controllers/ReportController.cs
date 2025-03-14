using AppWebMunicipale.Models;
using AppWebMunicipale.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebMunicipale.Controllers
{
    public class ReportController : Controller
    {
        private readonly VerbaleService _verbaleService;
        private readonly AnagraficaService _anagraficaService;

        public ReportController(VerbaleService verbaleService, AnagraficaService anagraficaService)
        {
            _verbaleService = verbaleService;
            _anagraficaService = anagraficaService;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> VerbaliPerTrasgressore()
        {
            var verbali = await _verbaleService.GetAllAsync();

            var verbaliPerTrasgressore = await Task.WhenAll(
                verbali
                    .GroupBy(v => v.IdAnagrafica)
                    .Select(async g =>
                    {
                        var trasgressoreNome = await _anagraficaService.GetByIdAsync(g.Key ?? 0);
                        return new Verbali
                        {
                            TrasgressoreId = g.Key ?? 0,
                            TrasgressoreNome = trasgressoreNome?.Nome ?? "Non disponibile",
                            Verbalis = g.ToList()
                        };
                    })
            );

            return View(verbaliPerTrasgressore);
        }

        public async Task<IActionResult> ViolazioniPuntiMaggioriDi10()
        {
            var verbali = await _verbaleService.GetAllAsync();

            var violazioniPuntiMaggioriDi10 = verbali
                .Where(v => v.DecurtamentoPunti >= 10)
                .Select(v => new ViolazioniOver10
                {
                    IdVerbale = v.IdVerbale,
                    DataViolazione = v.DataViolazione.ToDateTime(TimeOnly.MinValue), 
                    IndirizzoViolazione = v.IndirizzoViolazione,
                    NominativoAgente = v.NominativoAgente,
                    Importo = v.Importo,
                    DecurtamentoPunti = v.DecurtamentoPunti ?? 0
                })
                .ToList();

            return View(violazioniPuntiMaggioriDi10);
        }


        public async Task<IActionResult> PuntiDecurtatiPerTrasgressore()
        {
            var verbali = await _verbaleService.GetAllAsync();

            var puntiDecurtatiPerTrasgressore = await Task.WhenAll(
                verbali
                    .GroupBy(v => v.IdAnagrafica)
                    .Select(async g => new Punti
                    {
                        TrasgressoreId = g.Key ?? 0, 
                        TrasgressoreNome = (await _anagraficaService.GetByIdAsync(g.Key ?? 0))?.Nome ?? "Non disponibile", // Fixed: Added null-coalescing operator
                        TotalePunti = g.Sum(v => v.DecurtamentoPunti ?? 0)
                    })
            );

            return View(puntiDecurtatiPerTrasgressore);
        }



        public async Task<IActionResult> ViolazioniImportoMaggioreDi400()
        {
            var verbali = await _verbaleService.GetAllAsync();

            var violazioniImportoMaggioreDi400 = verbali
                .Where(v => v.Importo > 400)
                .Select(v => new ViolazioniOver400
                {
                    IdVerbale = v.IdVerbale,
                    DataViolazione = v.DataViolazione.ToDateTime(TimeOnly.MinValue), 
                    IndirizzoViolazione = v.IndirizzoViolazione,
                    NominativoAgente = v.NominativoAgente,
                    Importo = v.Importo,
                    DecurtamentoPunti = v.DecurtamentoPunti ?? 0
                })
                .ToList();

            return View(violazioniImportoMaggioreDi400);
        }


    }
}
