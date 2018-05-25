using FluentAssertions;
using NUnit.Framework;
using Prova2.Comum.Testes.Features.Livros;
using Prova2.Dominio.Exceptions;
using Prova2.Dominio.Features.Livros;
using Prova2.Dominio.Features.Livros.Exceptions;
using Prova2.Features.Livros;
using Prova2.Infra.Data.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prova2.Integracao.Testes.Features.Livros
{
    public class LivroIntegracaoSistema
    {
        LivroRepositorio _livroRepositorio = new LivroRepositorio();

        LivroService _livroService;

        [SetUp]
        public void TestSetup()
        {
            _livroService = new LivroService(_livroRepositorio);
        }

        [Test]
        public void LivroIntegracaoSistema_Adicionar_DeveSerValido()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            //Ação
            Livro livroResultado = _livroService.Adiciona(livro);

            //Verificar
            livroResultado.Should().NotBeNull();
            livroResultado.Id.Should().BeGreaterThan(0);
            livroResultado.Titulo.Should().Be(livro.Titulo);
            livroResultado.Tema.Should().Be(livro.Tema);
            livroResultado.Autor.Should().Be(livro.Autor);
            livroResultado.Volume.Should().Be(livro.Volume);

            Livro livroGet = _livroService.Obtem(livroResultado.Id);
            livroResultado.Id.Should().Be(livroGet.Id);

            _livroService.Exclui(livroResultado);
        }

        [Test]
        public void LivroIntegracaoSistema_Adicionar_TituloNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TituloNuloOuVazio();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroService.Adiciona(livro);

            //Verificar
            acaoResultado.Should().Throw<TituloNuloOuVazioException>();
        }

        [Test]
        public void LivroIntegracaoSistema_Adicionar_TemaNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TemaNuloOuVazio();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroService.Adiciona(livro);

            //Verificar
            acaoResultado.Should().Throw<TemaNuloOuVazioException>();
        }

        [Test]
        public void LivroIntegracaoSistema_Adicionar_AutorNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_AutorNuloOuVazio();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroService.Adiciona(livro);

            //Verificar
            acaoResultado.Should().Throw<AutorNuloOuVazioException>();
        }

        [Test]
        public void LivroIntegracaoSistema_Adicionar_TituloComCaracteresMinimos_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TituloComCaracteresMinimos();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroService.Adiciona(livro);

            //Verificar
            acaoResultado.Should().Throw<TituloComCaracteresMinimoException>();
        }

        [Test]
        public void LivroIntegracaoSistema_Adicionar_TemaComCaracteresMinimos_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TemaComCaracteresMinimos();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroService.Adiciona(livro);

            //Verificar
            acaoResultado.Should().Throw<TemaComCaracteresMinimoException>();
        }

        [Test]
        public void LivroIntegracaoSistema_Adicionar_AutorComCaracteresMinimos_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_AutorComCaracteresMinimos();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroService.Adiciona(livro);

            //Verificar
            acaoResultado.Should().Throw<AutorComCaracteresMinimoException>();
        }

        [Test]
        public void LivroIntegracaoSistema_Adicionar_VolumeIgualAZero_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_VolumeIgualZero();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroService.Adiciona(livro);

            //Verificar
            acaoResultado.Should().Throw<VolumeIgualZeroException>();
        }

        [Test]
        public void LivroIntegracaoSistema_Adicionar_DataPublicacaoInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_DataPublicacaoInvalida();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroService.Adiciona(livro);

            //Verificar
            acaoResultado.Should().Throw<DataDePublicacaoInvalidaException>();
        }

        [Test]
        public void LivroIntegracaoSistema_Atualizar_DeveSerValido()
        {
            //Cenário
            Livro livroParaEditar = _livroService.Obtem(1);
            livroParaEditar.Id = 1;
            string tituloAntigo = livroParaEditar.Titulo;
            string tituloNovo = "Titulo";

            if(tituloAntigo == tituloNovo)
            {
                tituloNovo = "Titulo novo";
            }

            livroParaEditar.Titulo = tituloNovo;

            //Ação
            Livro livroResultado = _livroService.Atualiza(livroParaEditar);

            //Verificar
            livroResultado.Titulo.Should().NotBe(tituloAntigo);
            livroResultado.Id.Should().Be(livroParaEditar.Id);
        }

        [Test]
        public void LivroIntegracaoSistema_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroService.Atualiza(livro);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void LivroIntegracaoSistema_Excluir_DeveSerValido()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            livro = _livroService.Adiciona(livro);

            //Ação
            _livroService.Exclui(livro);

            //Verificar
            Livro livroInexistente = _livroService.Obtem(livro.Id);
            livroInexistente.Should().BeNull();
        }

        [Test]
        public void LivroIntegracaoSistema_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            //Ação
            Action acaoResultado = () => _livroService.Exclui(livro);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void LivroIntegracaoSistema_Obter_DeveSerValido()
        {
            //Ação
            Livro livro = _livroService.Obtem(1);

            //Verificar
            livro.Id.Should().Be(1);
            livro.Should().NotBeNull();
        }

        [Test]
        public void LivroIntegracaoSistema_Obter_DeveRetornarExcecao()
        {
            //Ação
            Livro livroResultado = _livroService.Obtem(999999999);

            //Verificar
            livroResultado.Should().BeNull();
        }

        [Test]
        public void LivroIntegracaoSistema_ObterTudo_DeveSerValido()
        {
            //Cenário
            IEnumerable<Livro> listaLivro;

            //Ação
            listaLivro = _livroService.ObtemTudo();

            //Verificar
            listaLivro.Should().NotBeNull();
            listaLivro.Count().Should().BeGreaterOrEqualTo(0);
        }
    }
}
