using DonaLaura.Dominio.Features.Produtos;
using System;

namespace DonaLaura.Common.Tests.Features.Produtos
{
    public static partial class ObjectMother
    {
        public static Produto getValidoProduto()
        {
            return new Produto
            {
                Nome = "abcd",
                PrecoVenda = 3.45,
                PrecoCusto = 2.00,
                Disponibilidade = true,
                DataFabricacao = DateTime.Now.AddDays(-2),
                DataValidade = DateTime.Now.AddDays(3)
            };
        }

        public static Produto getNuloOuVazioNomeProduto()
        {
            return new Produto
            {
                Nome = "",
                PrecoVenda = 3.45,
                PrecoCusto = 2.00,
                Disponibilidade = true,
                DataFabricacao = DateTime.Now.AddDays(-2),
                DataValidade = DateTime.Now.AddDays(3)
            };
        }

        public static Produto getCaracteresMinimoNomeProduto()
        {
            return new Produto
            {
                Nome = "abc",
                PrecoVenda = 3.45,
                PrecoCusto = 2.00,
                Disponibilidade = true,
                DataFabricacao = DateTime.Now.AddDays(-2),
                DataValidade = DateTime.Now.AddDays(3)
            };
        }

        public static Produto getDataDeValidadeInvalidaProduto()
        {
            return new Produto
            {
                Nome = "abcd",
                PrecoVenda = 3.45,
                PrecoCusto = 2.00,
                Disponibilidade = true,
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddDays(-3)
            };
        }

        public static Produto getPrecoDeCustoInvalidoProduto()
        {
            return new Produto
            {
                Nome = "abcd",
                PrecoVenda = 3.45,
                PrecoCusto = 4.00,
                Disponibilidade = true,
                DataFabricacao = DateTime.Now.AddDays(-2),
                DataValidade = DateTime.Now.AddDays(3)
            };
        }

        public static Produto getDataDeFabricacaoInvalidaProduto()
        {
            return new Produto
            {
                Nome = "abcd",
                PrecoVenda = 3.45,
                PrecoCusto = 2.00,
                Disponibilidade = true,
                DataFabricacao = DateTime.Now.AddDays(2),
                DataValidade = DateTime.Now.AddDays(3)
            };
        }
    }
}
