using AppWebMunicipale.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebMunicipale.Services
{
    public class TipoViolazioneService
    {
        private readonly ApplicationDbContext _context;

        public TipoViolazioneService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoViolazione>> GetAllAsync()
        {
            return await _context.TipoViolaziones.ToListAsync();
        }

        public async Task<TipoViolazione> GetByIdAsync(int id)
        {
            return await _context.TipoViolaziones.FindAsync(id);
        }

        public async Task CreateAsync(TipoViolazione violazione)
        {
            _context.TipoViolaziones.Add(violazione);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoViolazione violazione)
        {
            _context.Entry(violazione).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var violazione = await _context.TipoViolaziones.FindAsync(id);
            if (violazione != null)
            {
                _context.TipoViolaziones.Remove(violazione);
                await _context.SaveChangesAsync();
            }
        }
    }


}
