using AppAmostras.Models;

namespace AppAmostras.Repositories
{
    public interface IAmostraRepository
    {
        Task<IEnumerable<Amostra>> GetAllAsync();
        Task<IEnumerable<Amostra>> GetAllAsync30();
        Task<Amostra?> GetIdAsync(int id);    
        Task CreateAsync(Amostra amostra);
        Task UpdateAsync(Amostra amostra);
        Task DeleteAsync(Amostra amostra);
    }
}
