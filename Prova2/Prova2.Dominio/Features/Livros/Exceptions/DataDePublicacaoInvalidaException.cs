using Prova2.Dominio.Exceptions;

namespace Prova2.Dominio.Features.Livros.Exceptions
{
    public class DataDePublicacaoInvalidaException : NegocioException
    {
        public DataDePublicacaoInvalidaException() : base("A data de publicação não pode ser maior que a data atual.")
        {
        }
    }
}
