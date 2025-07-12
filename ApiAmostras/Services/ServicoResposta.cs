namespace ApiAmostras.Services
{
    public class ServicoResposta
    {
        public record class RespostaGeral(bool Flag, string Message);
        public record class RespostaLogin(bool Flag, string Token, string Message);
    }
}
