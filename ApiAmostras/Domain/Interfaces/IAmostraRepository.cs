using ApiAmostras.Domain.Model;
using static ApiAmostras.Services.ServicoResposta;

namespace ApiAmostras.Domain.Interfaces
{
    public interface IAmostraRepository
    {
        Task<IEnumerable<Amostra>> GetAllAsync();       
        Task<Amostra?> GetIdAsync(int id);
        Task<RespostaGeral> CreateAsync(Amostra amostra);
        Task<RespostaGeral> UpdateAsync(Amostra amostra);
        Task<RespostaGeral> DeleteAsync(Amostra amostra);
    }
}
