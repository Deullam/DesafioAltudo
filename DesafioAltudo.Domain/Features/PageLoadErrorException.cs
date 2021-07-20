using DesafioAltudo.Domain.Exceptions;

namespace DesafioAltudo.Domain.Exceptions
{
    public class PageLoadErrorException : BusinessException
    {
        public PageLoadErrorException() : base(ErrorCodes.Unauthorized, "Erro ao carregar o conteúdo da página!")
        {
        }
    }
}

