using AppAmostras.Data;
using AppAmostras.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAmostras.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _Db;
        public StatusRepository(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await _Db.Status.OrderBy(o => o.Descricao).ToListAsync();
        }
        public async Task<Status?> GetIdAsync(int Id)
        {
            return await _Db.Status.FirstOrDefaultAsync(m => m.Id == Id);
        }
        public async Task CreateAsync(Status status)
        {
            await _Db.Status.AddAsync(status);
            await _Db.SaveChangesAsync();
        }
        public async Task UpdateAsync(Status status)
        {
            _Db.Status.Update(status);
            await _Db.SaveChangesAsync();
        }
        public async Task DeleteAsync(Status status)
        {
            _Db.Status.Remove(status!);
            await _Db.SaveChangesAsync();
        }
    }
}
