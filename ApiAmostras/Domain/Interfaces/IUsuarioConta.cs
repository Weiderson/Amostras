using ApiAmostras.Application.DTOs;
using ApiAmostras.Domain.Model;
using static ApiAmostras.Services.ServicoResposta;
namespace ApiAmostras.Domain.Interfaces
{ 
    public interface IUsuarioContaRepository
    {
        Task<RespostaGeral> CreateAccount(Usuario usuario);
        Task<RespostaLogin> LoginAccount(LoginDTO loginDTO);
    }
}
