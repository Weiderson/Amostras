using AppAmostras.Data;
using AppAmostras.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppAmostras.Repositories
{            
    public class AmostraRepository : IAmostraRepository
    {
        private readonly ApplicationDbContext _Db;
        public AmostraRepository(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        
        public async Task<IEnumerable<Amostra>> GetAllAsync()
        {
            IEnumerable<Amostra> amostras = Enumerable.Empty<Amostra>();
            amostras = await _Db.Amostras.Include(x => x.Status).OrderBy(o1 => o1.Codigo).ThenBy(o2 => o2.DataRecebimento).ToListAsync();
            return amostras;
        }

        public async Task<IEnumerable<Amostra>> GetAllAsync30()
        {
            IEnumerable<Amostra> amostras = Enumerable.Empty<Amostra>();
            amostras = await _Db.Amostras.Where(d => d.DataRecebimento > DateTime.Now.Date.AddDays(-30) && d.DataRecebimento < DateTime.Now.Date.AddDays(1)).Include(x => x.Status).OrderBy(o1 => o1.Codigo).ThenBy(o2 => o2.DataRecebimento).ToListAsync();
            return amostras;
        }

        public async Task<Amostra?> GetIdAsync(int id)
        {
            return await _Db.Amostras.Include(i => i.Status).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateAsync(Amostra amostra)
        {
            await _Db.Amostras.AddAsync(amostra);
            await _Db.SaveChangesAsync();            
        }

        public async Task UpdateAsync(Amostra amostra)
        {
            _Db.Amostras.Update(amostra);
            await _Db.SaveChangesAsync();
        }
            
        public async Task DeleteAsync(Amostra amostra)
        {
            //_Db.Amostras.Attach(amostra);
            //_Db.Entry(amostra).State = EntityState.Deleted;
            
            _Db.Amostras.Remove(amostra);
            await _Db.SaveChangesAsync();
        }
    }
}
