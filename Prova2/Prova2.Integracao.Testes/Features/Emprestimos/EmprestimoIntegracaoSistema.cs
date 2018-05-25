using FluentAssertions;
using NUnit.Framework;
using Prova2.Comum.Testes.Features.Emprestimos;
using Prova2.Dominio.Exceptions;
using Prova2.Dominio.Features.Emprestimos;
using Prova2.Dominio.Features.Emprestimos.Exceptions;
using Prova2.Dominio.Features.Livros;
using Prova2.Features.Emprestimos;
using Prova2.Infra.Data.Features.Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Integracao.Testes.Features.Emprestimos
{
    public class EmprestimoIntegracaoSistema
    {
        EmprestimoRepositorio _emprestimoRepositorio = new EmprestimoRepositorio();

        EmprestimoService _emprestimoService;

        [SetUp]
        public void TestSetup()
        {
            _emprestimoService = new EmprestimoService(_emprestimoRepositorio);
        }

        [Test]
        public void EmprestimoIntegracaoSistema_Adicionar_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            livro.Disponibilidade = true;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 0;
            emprestimo.Livro = livro;

            //Ação
            Emprestimo emprestimoResultado = _emprestimoService.Adiciona(emprestimo);

            //Verificar
            emprestimoResultado.Should().NotBeNull();
            emprestimoResultado.Id.Should().BeGreaterThan(0);
            emprestimoResultado.NomeCliente.Should().Be(emprestimo.NomeCliente);
            emprestimoResultado.Livro.Should().Be(emprestimo.Livro);
            emprestimoResultado.DataDevolucao.Should().BeBefore(DateTime.Now.AddDays(2));

            Emprestimo emprestimoGet = _emprestimoService.Obtem(emprestimoResultado.Id);
            emprestimoResultado.Id.Should().Be(emprestimoGet.Id);

            _emprestimoService.Exclui(emprestimoResultado);
        }

        [Test]
        public void EmprestimoIntegracaoSistema_Adicionar_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            livro.Disponibilidade = true;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoInvalido_NomeClienteNuloOuVazio();
            emprestimo.Id = 0;
            emprestimo.Livro = livro;

            //Ação
            Action acaoResultado = () => _emprestimoService.Adiciona(emprestimo);

            //Verificar
            acaoResultado.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void EmprestimoIntegracaoSistema_Adicionar_ProdutoIndisponivelParaEmprestimo_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            livro.Disponibilidade = false;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 0;
            emprestimo.Livro = livro;

            //Ação
            Action acaoResultado = () => _emprestimoService.Adiciona(emprestimo);

            //Verificar
            acaoResultado.Should().Throw<LivroIndisponivelException>();
        }

        [Test]
        public void EmprestimoIntegracaoSistema_Atualizar_DeveSerValido()
        {
            //Cenário
            Emprestimo emprestimoParaEditar = _emprestimoService.Obtem(1);
            emprestimoParaEditar.Id = 1;
            emprestimoParaEditar.Livro.Disponibilidade = true;
            string nomeAntigo = emprestimoParaEditar.NomeCliente;
            string nomeNovo = "Nome";

            if (nomeAntigo == nomeNovo)
            {
                nomeNovo = "Nome novo";
            }

            emprestimoParaEditar.NomeCliente = nomeNovo;

            //Ação
            Emprestimo emprestimoResultado = _emprestimoService.Atualiza(emprestimoParaEditar);

            //Verificar
            emprestimoResultado.NomeCliente.Should().NotBe(nomeAntigo);
            emprestimoResultado.Id.Should().Be(emprestimoParaEditar.Id);
        }

        [Test]
        public void EmprestimoIntegracaoSistema_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            livro.Disponibilidade = true;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 0;
            emprestimo.Livro = livro;

            //Ação
            Action acaoResultado = () => _emprestimoService.Atualiza(emprestimo);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void EmprestimoIntegracaoSistema_Excluir_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            livro.Disponibilidade = true;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 0;
            emprestimo.Livro = livro;

            emprestimo = _emprestimoService.Adiciona(emprestimo);

            //Ação
            _emprestimoService.Exclui(emprestimo);

            //Verificar
            Emprestimo emprestimoInexistente = _emprestimoService.Obtem(emprestimo.Id);
            emprestimoInexistente.Should().BeNull();
        }

        [Test]
        public void EmprestimoIntegracaoSistema_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            livro.Disponibilidade = true;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 0;
            emprestimo.Livro = livro;

            //Ação
            Action acaoResultado = () => _emprestimoService.Exclui(emprestimo);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void EmprestimoIntegracaoSistema_Obter_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            livro.Disponibilidade = true;
            livro.Titulo = "Titulo";
            livro.Tema = "Tema";
            livro.Autor = "Autor";
            livro.Volume = 1;
            livro.DataPublicacao = DateTime.Now.AddDays(-2);

            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 1;
            emprestimo.Livro = livro;

            //Ação
            emprestimo = _emprestimoService.Obtem(emprestimo.Id);

            //Verificar
            emprestimo.Id.Should().Be(1);
            emprestimo.Should().NotBeNull();
        }

        [Test]
        public void EmprestimoIntegracaoSistema_Obter_DeveRetornarExcecao()
        {
            //Ação
            Emprestimo emprestimoResultado = _emprestimoService.Obtem(999999999);

            //Verificar
            emprestimoResultado.Should().BeNull();
        }

        [Test]
        public void EmprestimoIntegracaoSistema_ObterTudo_DeveSerValido()
        {
            //Cenário
            IEnumerable<Emprestimo> listaEmprestimo;

            //Ação
            listaEmprestimo = _emprestimoService.ObtemTudo();

            //Verificar
            listaEmprestimo.Should().NotBeNull();
            listaEmprestimo.Count().Should().BeGreaterOrEqualTo(0);
        }
    }
}
