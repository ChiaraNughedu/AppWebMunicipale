using AppWebMunicipale.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebMunicipale.Services
{
    public class AnagraficaService
    {
        private readonly ApplicationDbContext _context;

        public AnagraficaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Anagrafica>> GetAllAsync()
        {
            return await _context.Anagraficas.ToListAsync();
        }

        public async Task<Anagrafica> GetByIdAsync(int id)
        {
            return await _context.Anagraficas.FindAsync(id);
        }
        public async Task CreateAsync(Anagrafica anagrafica)
        {
            _context.Anagraficas.Add(anagrafica);
            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(Anagrafica anagrafica)
        {
            _context.Anagraficas.Add(anagrafica);  // Aggiungi la nuova anagrafica al contesto
            await _context.SaveChangesAsync();  // Salva le modifiche nel database
        }

        public async Task UpdateAsync(Anagrafica anagrafica)
        {
            _context.Entry(anagrafica).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var anagrafica = await _context.Anagraficas.FindAsync(id);
            if (anagrafica != null)
            {
                _context.Anagraficas.Remove(anagrafica);
                await _context.SaveChangesAsync();
            }
        }
    }


}
