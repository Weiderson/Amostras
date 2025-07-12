namespace AppAmostras.Services
{
    public class ArquivoService : IArquivoService
    {
        public async Task<Byte[]> GetBytes(string conteudo)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(conteudo);         
            return bytes;
        }
    }
}
