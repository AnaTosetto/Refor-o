using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features;
using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Dominio.Features.Produtos;
using DonaLaura.Infra.Data.Features.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Tests.Features.Vendas
{
    public class VendaRepositoryTest
    {
        VendaRepository _vendaRepository;

        [SetUp]
        public void TestSetup()
        {
            VendaBaseSqlTest.SeedDatabase();
            _vendaRepository = new VendaRepository();
        }

        [Test]
        public void VendaRepository_Adicionar_DeveRetornarOk()
        {
            //Arrange
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 0;
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = id;
            venda.Produto = produto;

            //Action
            venda = _vendaRepository.Adicionar(venda);

            //Verify
            venda.Id.Should().BeGreaterThan(0);
        }
    }
}
