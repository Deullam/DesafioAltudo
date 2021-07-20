using DesafioAltudo.Domain.Exceptions;

namespace DesafioAltudo.Domain.Exceptions
{
    public class PageWordsListUninformedException : BusinessException
    {
        public PageWordsListUninformedException() : base(ErrorCodes.Unauthorized, "A Lista com as palavras deve ser informada!")
        {
        }
    }
}

