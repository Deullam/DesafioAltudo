using DesafioAltudo.Domain.Exceptions;

namespace DesafioAltudo.Domain.Exceptions
{
    public class PageUrlUninformedException : BusinessException
    {
        public PageUrlUninformedException() : base(ErrorCodes.Unauthorized, "A Url deve ser informada!")
        {
        }
    }
}

