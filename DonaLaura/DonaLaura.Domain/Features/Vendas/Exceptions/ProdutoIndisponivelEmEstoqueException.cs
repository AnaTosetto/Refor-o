using DonaLaura.Domain.Exceptions;

namespace DonaLaura.Domain.Features.Vendas.Exceptions
{
    public class ProdutoIndisponivelEmEstoqueException : NegocioException
    {
        public ProdutoIndisponivelEmEstoqueException() : base("Produto não está disponível.")
        {
        }
    }
}
