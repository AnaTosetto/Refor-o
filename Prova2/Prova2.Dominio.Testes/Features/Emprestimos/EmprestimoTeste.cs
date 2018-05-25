using FluentAssertions;
using Moq;
using NUnit.Framework;
using Prova2.Comum.Testes.Features.Emprestimos;
using Prova2.Dominio.Features.Emprestimos;
using Prova2.Dominio.Features.Emprestimos.Exceptions;
using Prova2.Dominio.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Dominio.Testes.Features.Emprestimos
{
    public class EmprestimoTeste
    {
        private Mock<Livro> _mockLivro;

        [SetUp]
        public void TestSetup()
        {
            _mockLivro = new Mock<Livro>();
        }

        [Test]
        public void Emprestimo_DeveSerValido()
        {
            //Cenário
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 1;
            emprestimo.Livro = _mockLivro.Object;

            _mockLivro.Setup(livro => livro.Disponibilidade).Returns(true);

            //Ação
            Action acaoResultado = emprestimo.Validar;

            //Verificar
            acaoResultado.Should().NotThrow();
        }

        [Test]
        public void Emprestimo_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoInvalido_NomeClienteNuloOuVazio();
            emprestimo.Id = 1;
            emprestimo.Livro = _mockLivro.Object;

            //Ação
            Action acaoResultado = () => emprestimo.Validar();

            //Verificar
            acaoResultado.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void Emprestimo_LivroIndisponivelParaEmprestimo_DeveRetornarExcecao()
        {
            //Cenário
            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 1;
            emprestimo.Livro = _mockLivro.Object;
            
            _mockLivro.Setup(livro => livro.Disponibilidade).Returns(false);
            //_mockLivro.Object.Disponibilidade = false;

            //Ação
            Action acaoResultado = () => emprestimo.Validar();

            //Verificar
            acaoResultado.Should().Throw<LivroIndisponivelException>();
        }

        [Test]
        public void Venda_ComMulta_DeveSerValido()
        {

            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 1;
            emprestimo.Livro = _mockLivro.Object;

            emprestimo.CalcularMulta(DateTime.Now.AddDays(3));

            emprestimo.Multa.Should().Be(2.5);
        }

        [Test]
        public void Venda_SemMulta_DeveSerValido()
        {

            Emprestimo emprestimo = ObjectMother.ObterEmprestimoValido();
            emprestimo.Id = 1;
            emprestimo.Livro = _mockLivro.Object;

            emprestimo.CalcularMulta(DateTime.Now.AddDays(2));

            emprestimo.Multa.Should().Be(0);
        }

    }
}
