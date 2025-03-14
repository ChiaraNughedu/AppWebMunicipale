using AppWebMunicipale.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebMunicipale.Services
{
    public class VerbaleService
    {
        private readonly ApplicationDbContext _context;

        public VerbaleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Verbale>> GetAllAsync()
        {
            return await _context.Verbales
                .Include(v => v.IdAnagraficaNavigation)    // Proprietà di navigazione corretta
                .Include(v => v.IdViolazioneNavigation)      // Proprietà di navigazione corretta
                .ToListAsync();
        }


        public async Task<Verbale> GetByIdAsync(int id)
        {
            return await _context.Verbales.Include(v => v.IdAnagraficaNavigation).Include(v => v.IdViolazioneNavigation).FirstOrDefaultAsync(v => v.IdVerbale == id);
        }

        public async Task CreateAsync(Verbale verbale)
        {
            _context.Verbales.Add(verbale);
            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(Verbale verbale)
        {
            _context.Verbales.Add(verbale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Verbale verbale)
        {
            _context.Entry(verbale).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var verbale = await _context.Verbales.FindAsync(id);
            if (verbale != null)
            {
                _context.Verbales.Remove(verbale);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Verbale>> GetByAnagraficaIdAsync(int anagraficaId)
        {
            return await _context.Verbales.Where(v => v.IdAnagrafica == anagraficaId).ToListAsync();
        }

        public async Task<decimal> GetTotalImportoAsync()
        {
            return await _context.Verbales.SumAsync(v => v.Importo);
        }

        public async Task<int> GetTotalPuntiByAnagraficaAsync(int anagraficaId)
        {
            return await _context.Verbales.Where(v => v.IdAnagrafica == anagraficaId).SumAsync(v => v.DecurtamentoPunti ?? 0);
        }
    }

}
