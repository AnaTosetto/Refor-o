using FluentAssertions;
using NUnit.Framework;
using Prova2.Comum.Testes.Features.Livros;
using Prova2.Dominio.Features.Livros;
using Prova2.Dominio.Features.Livros.Exceptions;
using System;

namespace Prova2.Dominio.Testes.Features.Livros
{
    [TestFixture]
    public class LivroTeste
    {
        [Test]
        public void Livro_DeveSerValido()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 1;

            //Ação
            Action acaoResultado = () => livro.Validar();

            //Verificar
            acaoResultado.Should().NotThrow();
        }
        [Test]
        public void Livro_TituloNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TituloNuloOuVazio();
            livro.Id = 1;

            //Ação
            Action acaoResultado = () => livro.Validar();

            //Verificar
            acaoResultado.Should().Throw<TituloNuloOuVazioException>();
        }

        [Test]
        public void Livro_TemaNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TemaNuloOuVazio();
            livro.Id = 1;

            //Ação
            Action acaoResultado = () => livro.Validar();

            //Verificar
            acaoResultado.Should().Throw<TemaNuloOuVazioException>();
        }

        [Test]
        public void Livro_AutorNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_AutorNuloOuVazio();
            livro.Id = 1;

            //Ação
            Action acaoResultado = () => livro.Validar();

            //Verificar
            acaoResultado.Should().Throw<AutorNuloOuVazioException>();
        }

        [Test]
        public void Livro_TituloComCarecteresMinimo_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TituloComCaracteresMinimos();
            livro.Id = 1;

            //Ação
            Action acaoResultado = () => livro.Validar();

            //Verificar
            acaoResultado.Should().Throw<TituloComCaracteresMinimoException>();
        }

        [Test]
        public void Livro_TemaComCarecteresMinimo_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TemaComCaracteresMinimos();
            livro.Id = 1;

            //Ação
            Action acaoResultado = () => livro.Validar();

            //Verificar
            acaoResultado.Should().Throw<TemaComCaracteresMinimoException>();
        }

        [Test]
        public void Livro_AutorComCarecteresMinimo_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_AutorComCaracteresMinimos();
            livro.Id = 1;

            //Ação
            Action acaoResultado = () => livro.Validar();

            //Verificar
            acaoResultado.Should().Throw<AutorComCaracteresMinimoException>();
        }

        [Test]
        public void Livro_VolumeIgualZero_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_VolumeIgualZero();
            livro.Id = 1;

            //Ação
            Action acaoResultado = () => livro.Validar();

            //Verificar
            acaoResultado.Should().Throw<VolumeIgualZeroException>();
        }

        [Test]
        public void Livro_DataPublicacaoInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_DataPublicacaoInvalida();
            livro.Id = 1;

            //Ação
            Action acaoResultado = () => livro.Validar();

            //Verificar
            acaoResultado.Should().Throw<DataDePublicacaoInvalidaException>();
        }
    }
}
