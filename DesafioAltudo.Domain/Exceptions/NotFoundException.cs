namespace DesafioAltudo.Domain.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException() : base(ErrorCodes.NotFound, "Registro não encontrado") { }
    }
}