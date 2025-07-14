using ApiAmostras.Domain.Interfaces;
using ApiAmostras.Domain.Model;
using Microsoft.EntityFrameworkCore;
using static ApiAmostras.Services.ServicoResposta;

namespace ApiAmostras.Infrastructure.Repositories
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
            amostras = await _Db.Amostras.ToListAsync();
            return amostras;
        }       

        public async Task<Amostra?> GetIdAsync(int id)
        {
            return await _Db.Amostras.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<RespostaGeral> CreateAsync(Amostra amostra)
        {
            var existeStatus = _Db.Status.Find(amostra.StatusId);
            if (existeStatus == null)
                return new RespostaGeral(false, "Status não encontrado.");

            await _Db.Amostras.AddAsync(amostra);
            var result = await _Db.SaveChangesAsync();
            // Verifica se o registro foi inserido com sucesso
            if (result <= 0)
                return new RespostaGeral(false, "Erro ao inserir amostra.");

            // Retorna sucesso se o registro foi gerado
            return new RespostaGeral(true, "Registro inserido.");            
        }

        public async Task<RespostaGeral> UpdateAsync(Amostra amostra)
        {          

            var existeAmostra = await GetIdAsync(amostra.Id);
            // Verifica se a amostra existe
            if (existeAmostra != null)
            {
                var existeStatus = _Db.Status.Find(amostra.StatusId);
                if (existeStatus != null)
                {
                    existeAmostra.Descricao = amostra.Descricao;
                    existeAmostra.Codigo = amostra.Codigo;
                    existeAmostra.StatusId = amostra.StatusId;
                    existeAmostra.DataRecebimento = amostra.DataRecebimento;
                    _Db.Amostras.Update(amostra);
                    var result = await _Db.SaveChangesAsync();

                    // Verifica se o registro foi atualizado com sucesso
                    if (result <= 0)
                        return new RespostaGeral(false, "Erro ao atualizar registro.");

                    // Retorna sucesso se o registro foi atualizado
                    return new RespostaGeral(true, "Registro atualizado.");
                }
               else
                {
                    return new RespostaGeral(false, "Status não encontrado.");
                }
                   
            }
            return new RespostaGeral(false, "Registro inexistente.");
        }
            
        public async Task<RespostaGeral> DeleteAsync(Amostra amostra)
        {
            _Db.Amostras.Remove(amostra);
            var result = await _Db.SaveChangesAsync();
            if (result <= 0)
                return new RespostaGeral(false, "Erro ao atualizar amostra.");

            // Retorna sucesso se o registro foi removido
            return new RespostaGeral(true, "Registro excluído.");
        }
    }
}
