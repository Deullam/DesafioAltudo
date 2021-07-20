using System;

namespace DesafioAltudo.Domain.Exceptions
{
    public class IdentifierUndefinedException : Exception
    {
        public IdentifierUndefinedException() : base("O Id não foi informado.")
        {

        }
    }
}
