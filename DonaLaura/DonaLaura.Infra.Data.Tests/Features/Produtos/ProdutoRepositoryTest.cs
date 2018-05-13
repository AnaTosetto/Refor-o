using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features;
using DonaLaura.Dominio.Features.Produtos;
using DonaLaura.Infra.Data.Features.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Tests.Features.Produtos
{
    public class ProdutoRepositoryTest
    {
        ProdutoRepository _produtoRepository;

        [SetUp]
        public void TestSetup()
        {
             ProdutoBaseSqlTest.SeedDatabase();
            _produtoRepository = new ProdutoRepository();
        }

        [Test]
        public void ProdutoRepository_Adicionar_DeveRetornarOK()
        {
            //Arrange
            int id = 0;
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = id;

            //Action
            produto = _produtoRepository.Adicionar(produto);

            //Verify
            produto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoRepository_Atualizar_DeveRetornarOk()
        {
            //Arrange
            int id = 1;
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = id;

            //Action
            produto = _produtoRepository.Atualizar(produto);

            //Verify
            produto.Id.Should().Be(produto.Id);
        }
    }
}
