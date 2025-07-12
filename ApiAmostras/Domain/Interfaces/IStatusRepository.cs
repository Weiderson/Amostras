using ApiAmostras.Domain.Model;
using static ApiAmostras.Services.ServicoResposta;

namespace ApiAmostras.Domain.Interfaces
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllAsync();
        Task<Status?> GetIdAsync(int id);
        Task<RespostaGeral> CreateAsync(Status status);
        Task<RespostaGeral> UpdateAsync(Status status);
        Task<RespostaGeral> DeleteAsync(Status status);
    }
}
