using ApiAmostras.Domain.Interfaces;
using ApiAmostras.Domain.Model;
using Microsoft.EntityFrameworkCore;
using static ApiAmostras.Services.ServicoResposta;

namespace ApiAmostras.Infrastructure.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _Db;
        public StatusRepository(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        public async Task<List<Status>> GetAllAsync()
        {
            return await _Db.Status.OrderBy(o => o.Descricao).ToListAsync();
        }
        public async Task<Status?> GetIdAsync(int id)
        {
            return await _Db.Status.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<RespostaGeral> CreateAsync(Status status)
        {
            await _Db.Status.AddAsync(status);
            var result = await _Db.SaveChangesAsync();
            // Verifica se o registro foi inserido com sucesso
            if (result <= 0)
                return new RespostaGeral(false, "Erro ao inserir amostra.");

            // Retorna sucesso se o registro foi gerado
            return new RespostaGeral(true, "Registro inserido.");
        }
        public async Task<RespostaGeral> UpdateAsync(Status status)
        {
            var existeStatus = await GetIdAsync(status.Id);
            // Verifica se o status existe
            if (existeStatus != null)
            {
                existeStatus.Descricao = status.Descricao;
                _Db.Status.Update(existeStatus);
                var result = await _Db.SaveChangesAsync();
                
                // Verifica se o registro foi atualizado com sucesso
                if (result <= 0)
                    return new RespostaGeral(false, "Erro ao atualizar registro.");

                // Retorna sucesso se o registro foi atualizado
                return new RespostaGeral(true, "Registro atualizado.");
            }
            return new RespostaGeral(false, "Registro inexistente.");
        }
        public async Task<RespostaGeral> DeleteAsync(Status status)
        {
            _Db.Status.Remove(status!);
            var result = await _Db.SaveChangesAsync();
            if (result <= 0)
                return new RespostaGeral(false, "Erro ao atualizar amostra.");

            // Retorna sucesso se o registro foi removido
            return new RespostaGeral(true, "Registro excluído.");
        }
    }
}
