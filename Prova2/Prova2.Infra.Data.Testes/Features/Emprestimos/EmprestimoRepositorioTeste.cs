using FluentAssertions;
using NUnit.Framework;
using Prova2.Comum.Testes.Base.Emprestimos;
using Prova2.Comum.Testes.Features.Emprestimos;
using Prova2.Dominio.Exceptions;
using Prova2.Dominio.Features.Emprestimos;
using Prova2.Dominio.Features.Livros;
using Prova2.Infra.Data.Features.Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Infra.Data.Testes.Features.Emprestimos
{
    public class EmprestimoRepositorioTeste
    {
        EmprestimoRepositorio _emprestimoRepositorio;

        [SetUp]
        public void TesteSetup()
        {
            BaseSqlTeste.SeedDatabase();
            _emprestimoRepositorio = new EmprestimoRepositorio();
        }

        [Test]
        public void EmprestimoRepositorio_Adicionar_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            livro.Disponibilidade = true;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 0;
            emprestimo.Livro = livro;

            //Ação
            emprestimo = _emprestimoRepositorio.Adicionar(emprestimo);

            //Verificar
            emprestimo.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void EmprestimoRepositorio_Atualizar_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            livro.Disponibilidade = true;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 1;
            emprestimo.Livro = livro;

            //Ação
            emprestimo = _emprestimoRepositorio.Atualizar(emprestimo);

            //Verificar
            emprestimo.Id.Should().Be(emprestimo.Id);
        }

        [Test]
        public void EmprestimoRepositorio_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            livro.Disponibilidade = true;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 0;
            emprestimo.Livro = livro;

            //Ação
            Action acaoResultado = () => _emprestimoRepositorio.Atualizar(emprestimo);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void EmprestimoRepositorio_Excluir_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 1;
            emprestimo.Livro = livro;

            //Ação
            _emprestimoRepositorio.Excluir(emprestimo);
        }

        [Test]
        public void EmprestimoRepositorio_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 0;
            emprestimo.Livro = livro;

            //Ação
            Action acaoResultado = () => _emprestimoRepositorio.Excluir(emprestimo);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void EmprestimoRepositorio_Obter_DeveSerValido()
        {
            //Cenário
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.Id = 1;

            //Ação
            emprestimo = _emprestimoRepositorio.Obter(emprestimo.Id);
        }

        [Test]
        public void EmprestimoRepositorio_Obter_DeveRetornarExcecao()
        {
            //Cenário
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.Id = 0;

            //Ação
            Action acaoResultado = () => _emprestimoRepositorio.Obter(emprestimo.Id);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void EmprestimoRepositorio_ObterTudo_DeveSerValido()
        {
            //Cenário
            IEnumerable<Emprestimo> listaEmprestimo;

            //Ação
            listaEmprestimo = _emprestimoRepositorio.ObterTudo();

            //Verificar
            listaEmprestimo.Should().NotBeNull();
            listaEmprestimo.First<Emprestimo>().Id.Should().Be(1);
        }

    }
}
