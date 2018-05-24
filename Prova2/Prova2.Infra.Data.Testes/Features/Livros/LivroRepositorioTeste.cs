using FluentAssertions;
using NUnit.Framework;
using Prova2.Comum.Testes.Base.Livros;
using Prova2.Comum.Testes.Features.Livros;
using Prova2.Dominio.Exceptions;
using Prova2.Dominio.Features.Livros;
using Prova2.Infra.Data.Features.Livros;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Prova2.Infra.Data.Testes.Features.Livros
{
    public class LivroRepositorioTeste
    {
        LivroRepositorio _livroRepositorio;

        [SetUp]
        public void TestSetup()
        {
            BaseSqlTeste.SeedDatabase();
            _livroRepositorio = new LivroRepositorio();
        }

        [Test]
        public void LivroRepositorio_Adicionar_DeveSerValido()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            //Ação
            livro = _livroRepositorio.Adicionar(livro);

            //Verificar
            livro.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void LivroRepositorio_Adicionar_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroRepositorio.Adicionar(livro);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void LivroRepositorio_Atualizar_DeveSerValido()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 1;

            //Ação
            livro = _livroRepositorio.Atualizar(livro);

            //Verificar
            livro.Id.Should().Be(livro.Id);
        }

        [Test]
        public void LivroRepositorio_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroRepositorio.Atualizar(livro);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void LivroRepositorio_Excluir_DeveSerValido()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 1;

            //Ação
            _livroRepositorio.Excluir(livro);
        }

        [Test]
        public void LivroRepositorio_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroRepositorio.Excluir(livro);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void LivroRepositorio_Obter_DeveSerValido()
        {
            //Cenário
            Livro livro = new Livro();
            livro.Id = 1;

            //Ação
            livro = _livroRepositorio.Obter(livro.Id);
        }

        [Test]
        public void LivroRepositorio_Obter_DeveRetornarExcecao()
        {
            //Cenário 
            Livro livro = new Livro();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroRepositorio.Obter(livro.Id);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void LivroRepositorio_ObterTudo_DeveSerValido()
        {
            //Cenário
            IEnumerable<Livro> listaLivro;

            //Ação
            listaLivro = _livroRepositorio.ObterTudo();

            //Verificar
            listaLivro.Should().NotBeNull();
            listaLivro.First<Livro>().Id.Should().Be(1);
        }
    }
}
