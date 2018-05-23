using FluentAssertions;
using Moq;
using NUnit.Framework;
using Prova2.Comum.Testes.Features.Emprestimos;
using Prova2.Dominio.Features.Emprestimos;
using Prova2.Dominio.Features.Emprestimos.Exceptions;
using Prova2.Dominio.Features.Livros;
using Prova2.Features.Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prova2.Aplicacao.Testes.Features.Emprestimos
{
    public class EmprestimoServiceTeste
    {
        EmprestimoService _emprestimoService;

        private Mock<IEmprestimoRepositorio> _mockEmprestimoRepositorio;

        [SetUp]
        public void TesteSetup()
        {
            _mockEmprestimoRepositorio = new Mock<IEmprestimoRepositorio>();
            _emprestimoService = new EmprestimoService(_mockEmprestimoRepositorio.Object);
        }

        [Test]
        public void EmprestimoService_Adiciona_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido(livro);
            emprestimo.Id = 0;
            emprestimo.Livro = livro;
            emprestimo.Livro.Disponibilidade = true;

            //Ação
            _mockEmprestimoRepositorio.Setup(rp => rp.Adicionar(emprestimo)).Returns(new Emprestimo { Id = 1, NomeCliente = "nome", DataDevolucao = DateTime.Now.AddDays(2), Livro = livro});
            Emprestimo retorno = _emprestimoService.Adiciona(emprestimo);

            //Verificar
            _mockEmprestimoRepositorio.Verify(rp => rp.Adicionar(emprestimo));
            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
            retorno.Id.Should().NotBe(emprestimo.Id);
        }

        [Test]
        public void EmprestimoService_Adiciona_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoInvalido_NomeClienteNuloOuVazio(livro);
            emprestimo.Id = 0;

            _mockEmprestimoRepositorio.Setup(rp => rp.Adicionar(emprestimo)).Returns(new Emprestimo { Id = 1, NomeCliente = "nome", DataDevolucao = DateTime.Now.AddDays(2), Livro = livro });

            //Ação
            Action acaoRetorno = () => _emprestimoService.Adiciona(emprestimo);

            //Verificar
            acaoRetorno.Should().Throw<NomeNuloOuVazioException>();
            _mockEmprestimoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void EmprestimoService_Adiciona_ProdutoIndisponivelParaEmprestimo_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido(livro);
            emprestimo.Id = 0;
            emprestimo.Livro = livro;
            emprestimo.Livro.Disponibilidade = false;

            _mockEmprestimoRepositorio.Setup(rp => rp.Adicionar(emprestimo)).Returns(new Emprestimo { Id = 1, NomeCliente = "nome", DataDevolucao = DateTime.Now.AddDays(2), Livro = livro });

            //Ação
            Action acaoRetorno = () => _emprestimoService.Adiciona(emprestimo);

            //Verificar
            acaoRetorno.Should().Throw<LivroIndisponivelException>();
            _mockEmprestimoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void EmprestimoService_Atualiza_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido(livro);
            emprestimo.Id = 1;
            emprestimo.Livro = livro;
            emprestimo.Livro.Disponibilidade = true;

            _mockEmprestimoRepositorio.Setup(rp => rp.Atualizar(emprestimo)).Returns(new Emprestimo { Id = emprestimo.Id, NomeCliente = "nome cliente", DataDevolucao = DateTime.Now.AddDays(2), Livro = livro });

            //Ação
            Emprestimo retorno = _emprestimoService.Atualiza(emprestimo);

            //Verificar
            _mockEmprestimoRepositorio.Verify(rp => rp.Atualizar(emprestimo));
            retorno.Should().NotBeNull();
            retorno.Id.Should().Be(emprestimo.Id);
        }

        [Test]
        public void EmprestimoService_Exclui_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido(livro);
            emprestimo.Id = 1;

            _mockEmprestimoRepositorio.Setup(rp => rp.Excluir(emprestimo));

            //Ação
            _emprestimoService.Exclui(emprestimo);

            //Verificar
            _mockEmprestimoRepositorio.Verify(rp => rp.Excluir(emprestimo));
        }

        [Test]
        public void EmprestimoService_Obtem_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido(livro);
            livro.Id = 1;

            _mockEmprestimoRepositorio.Setup(rp => rp.Obter(emprestimo.Id)).Returns(new Emprestimo { Id = 1, NomeCliente = "nome cliente", DataDevolucao = DateTime.Now.AddDays(2), Livro = livro });

            //Ação
            Emprestimo retorno = _emprestimoService.Obtem(emprestimo.Id);

            //Verificar
            _mockEmprestimoRepositorio.Verify(rp => rp.Obter(emprestimo.Id));

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void EmprestimoService_ObtemTudo_DeveSerValido()
        {
            //Cenário
            _mockEmprestimoRepositorio.Setup(rp => rp.ObterTudo()).Returns(Enumerable.Empty<Emprestimo>);

            //Ação
            IEnumerable<Emprestimo> retorno = _emprestimoService.ObtemTudo();

            //Verificar
            foreach (Emprestimo emprestimo in retorno)
            {
                emprestimo.Id.Should().BeGreaterThan(0);
                emprestimo.Should().NotBeNull();
            }

            _mockEmprestimoRepositorio.Verify(rp => rp.ObterTudo());
        }
    }
}
