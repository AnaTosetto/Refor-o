using FluentAssertions;
using Moq;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios.Excecoes;
using SalaDeReuniao.Funcionalidades.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Aplicacao.Testes.Funcionalidades.Funcionarios
{
    public class FuncionarioServiceTeste
    {
        FuncionarioService _funcionarioService;

        private Mock<IFuncionarioRepositorio> _mockFuncionarioRepositorio;

        [SetUp]
        public void Inicializar()
        {
            _mockFuncionarioRepositorio = new Mock<IFuncionarioRepositorio>();
            _funcionarioService = new FuncionarioService(_mockFuncionarioRepositorio.Object);
        }

        [Test]
        public void FuncionarioService_Adicionar_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 0;

            _mockFuncionarioRepositorio.Setup(rp => rp.Adicionar(funcionario)).Returns(new Funcionario { Id = 1, Cargo = "cargo", Nome = "nome", Ramal = "ramal" });

            //Ação
            Funcionario retorno = _funcionarioService.Adicionar(funcionario);

            //Verificar
            _mockFuncionarioRepositorio.Verify(rp => rp.Adicionar(funcionario));
            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
            retorno.Id.Should().NotBe(funcionario.Id);
        }

        [Test]
        public void FuncionarioService_Adicionar_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioInvalido_NomeNuloOuVazio();
            funcionario.Id = 0;

            _mockFuncionarioRepositorio.Setup(rp => rp.Adicionar(funcionario)).Returns(new Funcionario { Id = 1, Cargo = "cargo", Nome = "nome", Ramal = "ramal" });

            //Ação
            Action acaoResultado = () => _funcionarioService.Adicionar(funcionario);

            //Verificar
            acaoResultado.Should().Throw<NomeNuloOuVazioException>();
            _mockFuncionarioRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void FuncionarioService_Adicionar_CargoNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioInvalido_CargoNuloOuVazio();
            funcionario.Id = 0;

            _mockFuncionarioRepositorio.Setup(rp => rp.Adicionar(funcionario)).Returns(new Funcionario { Id = 1, Cargo = "cargo", Nome = "nome", Ramal = "ramal" });

            //Ação
            Action acaoResultado = () => _funcionarioService.Adicionar(funcionario);

            //Verificar
            acaoResultado.Should().Throw<CargoNuloOuVazioException>();
            _mockFuncionarioRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void FuncionarioService_Adicionar_RamalNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioInvalido_RamalNuloOuVazio();
            funcionario.Id = 0;

            _mockFuncionarioRepositorio.Setup(rp => rp.Adicionar(funcionario)).Returns(new Funcionario { Id = 1, Cargo = "cargo", Nome = "nome", Ramal = "ramal" });

            //Ação
            Action acaoResultado = () => _funcionarioService.Adicionar(funcionario);

            //Verificar
            acaoResultado.Should().Throw<RamalNuloOuVazioException>();
            _mockFuncionarioRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void FuncionarioService_Atualizar_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 1;

            _mockFuncionarioRepositorio.Setup(rp => rp.Atualizar(funcionario)).Returns(new Funcionario { Id = funcionario.Id, Cargo = "cargo", Nome = "nome", Ramal = "ramal" });

            //Ação
            Funcionario retorno = _funcionarioService.Atualizar(funcionario);

            //Verificar
            _mockFuncionarioRepositorio.Verify(rp => rp.Atualizar(funcionario));
            retorno.Should().NotBeNull();
            retorno.Id.Should().Be(funcionario.Id);
        }

        [Test]
        public void FuncionarioService_Excluir_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 1;

            _mockFuncionarioRepositorio.Setup(rp => rp.Excluir(funcionario));

            //Ação
            _funcionarioService.Excluir(funcionario);

            //Verificar
            _mockFuncionarioRepositorio.Verify(rp => rp.Excluir(funcionario));
        }

        [Test]
        public void FuncionarioService_Obter_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 1;

            _mockFuncionarioRepositorio.Setup(rp => rp.Obter(funcionario.Id)).Returns(new Funcionario { Id = 1, Cargo = "cargo", Nome = "nome", Ramal = "ramal" });

            //Ação
            Funcionario retorno = _funcionarioService.Obter(funcionario.Id);

            //Verificar
            _mockFuncionarioRepositorio.Verify(rp => rp.Obter(funcionario.Id));

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void FuncionarioService_ObterTudo_DeveSerValido()
        {
            //Cenário
            _mockFuncionarioRepositorio.Setup(rp => rp.ObterTudo()).Returns(Enumerable.Empty<Funcionario>);

            //Ação
            IEnumerable<Funcionario> retorno = _funcionarioService.ObterTudo();

            //Verificar
            foreach (Funcionario funcionario in retorno)
            {
                funcionario.Id.Should().BeGreaterThan(0);
                funcionario.Should().NotBeNull();
            }

            _mockFuncionarioRepositorio.Verify(rp => rp.ObterTudo());
        }

    }
}
