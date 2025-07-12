namespace AppAmostras.Services
{
    public interface IArquivoService
    {          
        Task<Byte[]> GetBytes(string conteudo);
    }      
}
