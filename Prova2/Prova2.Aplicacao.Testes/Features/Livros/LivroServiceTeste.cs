using FluentAssertions;
using Moq;
using NUnit.Framework;
using Prova2.Comum.Testes.Features.Livros;
using Prova2.Dominio.Features.Livros;
using Prova2.Dominio.Features.Livros.Exceptions;
using Prova2.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Aplicacao.Testes.Features.Livros
{
    public class LivroServiceTeste
    {
        LivroService _livroService;

        private Mock<ILivroRepositorio> _mockLivroRepositorio;

        [SetUp]
        public void TesteSetup()
        {
            _mockLivroRepositorio = new Mock<ILivroRepositorio>();
            _livroService = new LivroService(_mockLivroRepositorio.Object);
        }

        [Test]
        public void LivroService_Adiciona_DeveSerValido()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            //Ação
            _mockLivroRepositorio.Setup(rp => rp.Adicionar(livro)).Returns(new Livro { Id = 1, Tema = "tema", Titulo = "titulo", Autor = "autor", Volume = 1, DataPublicacao = DateTime.Now.AddDays(-2), Disponibilidade = true });
            Livro retorno = _livroService.Adiciona(livro);

            //Verificar
            _mockLivroRepositorio.Verify(rp => rp.Adicionar(livro));
            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
            retorno.Id.Should().NotBe(livro.Id);
        }

        [Test]
        public void LivroService_Adiciona_TituloNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TituloNuloOuVazio();
            livro.Id = 0;

            _mockLivroRepositorio.Setup(rp => rp.Adicionar(livro)).Returns(new Livro { Id = 1, Tema = "tema", Titulo = "titulo", Autor = "autor", Volume = 1, DataPublicacao = DateTime.Now.AddDays(-2), Disponibilidade = true });
            
            //Ação
            Action acaoRetorno = ()  => _livroService.Adiciona(livro);

            //Verificar
            acaoRetorno.Should().Throw<TituloNuloOuVazioException>();
            _mockLivroRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Adiciona_TemaNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TemaNuloOuVazio();
            livro.Id = 0;

            _mockLivroRepositorio.Setup(rp => rp.Adicionar(livro)).Returns(new Livro { Id = 1, Tema = "tema", Titulo = "titulo", Autor = "autor", Volume = 1, DataPublicacao = DateTime.Now.AddDays(-2), Disponibilidade = true });

            //Ação
            Action acaoRetorno = () => _livroService.Adiciona(livro);

            //Verificar
            acaoRetorno.Should().Throw<TemaNuloOuVazioException>();
            _mockLivroRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Adiciona_AutorNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_AutorNuloOuVazio();
            livro.Id = 0;

            _mockLivroRepositorio.Setup(rp => rp.Adicionar(livro)).Returns(new Livro { Id = 1, Tema = "tema", Titulo = "titulo", Autor = "autor", Volume = 1, DataPublicacao = DateTime.Now.AddDays(-2), Disponibilidade = true });

            //Ação
            Action acaoRetorno = () => _livroService.Adiciona(livro);

            //Verificar
            acaoRetorno.Should().Throw<AutorNuloOuVazioException>();
            _mockLivroRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Adiciona_TituloComCaracteresMinimo_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TituloComCaracteresMinimos();
            livro.Id = 0;

            _mockLivroRepositorio.Setup(rp => rp.Adicionar(livro)).Returns(new Livro { Id = 1, Tema = "tema", Titulo = "titulo", Autor = "autor", Volume = 1, DataPublicacao = DateTime.Now.AddDays(-2), Disponibilidade = true });

            //Ação
            Action acaoRetorno = () => _livroService.Adiciona(livro);

            //Verificar
            acaoRetorno.Should().Throw<TituloComCaracteresMinimoException>();
            _mockLivroRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Adiciona_TemaComCaracteresMinimo_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_TemaComCaracteresMinimos();
            livro.Id = 0;

            _mockLivroRepositorio.Setup(rp => rp.Adicionar(livro)).Returns(new Livro { Id = 1, Tema = "tema", Titulo = "titulo", Autor = "autor", Volume = 1, DataPublicacao = DateTime.Now.AddDays(-2), Disponibilidade = true });

            //Ação
            Action acaoRetorno = () => _livroService.Adiciona(livro);

            //Verificar
            acaoRetorno.Should().Throw<TemaComCaracteresMinimoException>();
            _mockLivroRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Adiciona_AutorComCaracteresMinimo_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_AutorComCaracteresMinimos();
            livro.Id = 0;

            _mockLivroRepositorio.Setup(rp => rp.Adicionar(livro)).Returns(new Livro { Id = 1, Tema = "tema", Titulo = "titulo", Autor = "autor", Volume = 1, DataPublicacao = DateTime.Now.AddDays(-2), Disponibilidade = true });

            //Ação
            Action acaoRetorno = () => _livroService.Adiciona(livro);

            //Verificar
            acaoRetorno.Should().Throw<AutorComCaracteresMinimoException>();
            _mockLivroRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Adiciona_VolumeIgualZero_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_VolumeIgualZero();
            livro.Id = 0;

            _mockLivroRepositorio.Setup(rp => rp.Adicionar(livro)).Returns(new Livro { Id = 1, Tema = "tema", Titulo = "titulo", Autor = "autor", Volume = 1, DataPublicacao = DateTime.Now.AddDays(-2), Disponibilidade = true });

            //Ação
            Action acaoRetorno = () => _livroService.Adiciona(livro);

            //Verificar
            acaoRetorno.Should().Throw<VolumeIgualZeroException>();
            _mockLivroRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Adiciona_DataPublicacaoInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroInvalido_DataPublicacaoInvalida();
            livro.Id = 0;

            _mockLivroRepositorio.Setup(rp => rp.Adicionar(livro)).Returns(new Livro { Id = 1, Tema = "tema", Titulo = "titulo", Autor = "autor", Volume = 1, DataPublicacao = DateTime.Now.AddDays(-2), Disponibilidade = true });

            //Ação
            Action acaoRetorno = () => _livroService.Adiciona(livro);

            //Verificar
            acaoRetorno.Should().Throw<DataDePublicacaoInvalidaException>();
            _mockLivroRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Atualiza_DeveSerValido()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 1;

            _mockLivroRepositorio.Setup(rp => rp.Atualizar(livro)).Returns(new Livro { Id = livro.Id, Tema = "tema", Titulo = "titulo", Autor = "autor", Volume = 1, DataPublicacao = DateTime.Now.AddDays(-2), Disponibilidade = true });

            //Ação
            Livro retorno = _livroService.Atualiza(livro);

            //Verificar
            _mockLivroRepositorio.Verify(rp => rp.Atualizar(livro));
            retorno.Should().NotBeNull();
            retorno.Id.Should().Be(livro.Id);
        }

        [Test]
        public void LivroService_Exclui_DeveSerValido()
        {
            //Cenário

        }

    }
}
