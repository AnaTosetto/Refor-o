using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Dominio.Features.Produtos;

namespace DonaLaura.Common.Tests.Features.Vendas
{
    public static partial class ObjectMother
    {
        public static Venda getQuantidadeMenorOuIgualZeroVenda(Produto produto)
        {
            return new Venda
            {
                NomeCliente = "nome",
                Quantidade = 0,
                Lucro = 3.50,
                Produto = produto
            };
        }

        public static Venda getNomeNuloOuVazioVenda(Produto produto)
        {
            return new Venda
            {
                NomeCliente = "",
                Quantidade = 1,
                Lucro = 3.50,
                Produto = produto
            };
        }

        public static Venda getValidoVenda(Produto produto)
        {
            return new Venda
            {
                NomeCliente = "nome",
                Quantidade = 1,
                Lucro = 3.50,
                Produto = produto
            };
        }
    }
}
