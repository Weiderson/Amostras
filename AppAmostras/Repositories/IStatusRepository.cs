using AppAmostras.Models;

namespace AppAmostras.Repositories
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllAsync();
        Task<Status?> GetIdAsync(int Id);
        Task CreateAsync(Status status);
        Task UpdateAsync(Status status);
        Task DeleteAsync(Status status);
    }
}
