using FluentAssertions;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios.Excecoes;
using SalaDeReuniao.Funcionalidades.Funcionarios;
using SalaDeReuniao.Infra.Data.Funcionalidades.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Integracao.Testes.Funcionalidades.Funcionarios
{
    public class FuncionarioIntegracaoSistema
    {
        FuncionarioRepositorio _funcionarioRepositorio = new FuncionarioRepositorio();

        FuncionarioService _funcionarioService;

        [SetUp]
        public void Inicializar()
        {
            _funcionarioService = new FuncionarioService(_funcionarioRepositorio);
        }

        [Test]
        public void FuncionarioIntegracaoSistema_Adicionar_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 0;

            //Ação
            Funcionario funcionarioResultado = _funcionarioService.Adicionar(funcionario);

            //Verificar
            funcionarioResultado.Should().NotBeNull();
            funcionarioResultado.Id.Should().BeGreaterThan(0);
            funcionarioResultado.Nome.Should().Be(funcionario.Nome);
            funcionarioResultado.Cargo.Should().Be(funcionario.Cargo);
            funcionarioResultado.Ramal.Should().Be(funcionario.Ramal);

            Funcionario funcionarioGet = _funcionarioService.Obter(funcionarioResultado.Id);
            funcionarioResultado.Id.Should().Be(funcionarioGet.Id);

            _funcionarioService.Excluir(funcionarioResultado);
        }

        [Test]
        public void FuncionarioIntegracaoSistema_Adicionar_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioInvalido_NomeNuloOuVazio();
            funcionario.Id = 0;

            //Ação
            Action acaoResultado = () => _funcionarioService.Adicionar(funcionario);

            //Verificar
            acaoResultado.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void FuncionarioIntegracaoSistema_Atualizar_DeveSerValido()
        {
            //Cenário
            Funcionario funcionarioParaEditar = _funcionarioService.Obter(1);
            funcionarioParaEditar.Id = 1;
            string nomeAntigo = funcionarioParaEditar.Nome;
            string nomeNovo = "Nome";

            if (nomeAntigo == nomeNovo)
            {
                nomeNovo = "Nome novo";
            }

            funcionarioParaEditar.Nome = nomeNovo;

            //Ação
            Funcionario funcionarioResultado = _funcionarioService.Atualizar(funcionarioParaEditar);

            //Verificar
            funcionarioResultado.Nome.Should().NotBe(nomeAntigo);
            funcionarioResultado.Id.Should().Be(funcionarioParaEditar.Id);
        }

        [Test]
        public void FuncionarioIntegracaoSistema_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 0;

            //Ação
            Action acaoResultado = () => _funcionarioService.Atualizar(funcionario);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void FuncionarioIntegracaoSistema_Excluir_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 0;

            funcionario = _funcionarioService.Adicionar(funcionario);

            //Ação
            _funcionarioService.Excluir(funcionario);

            //Verificar
            Funcionario funcionarioInexistente = _funcionarioService.Obter(funcionario.Id);
            funcionarioInexistente.Should().BeNull();
        }

        [Test]
        public void FuncionarioIntegracaoSistema_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 0;

            //Ação
            Action acaoResultado = () => _funcionarioService.Excluir(funcionario);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void FuncionariointegracaoSistema_Obter_DeveSerValido()
        {
            //Ação
            Funcionario funcionario = _funcionarioService.Obter(1);

            //Verificar
            funcionario.Id.Should().Be(1);
            funcionario.Should().NotBeNull();
        }

        [Test]
        public void FuncionarioIntegracaoSistema_Obter_DeveRetornarExcecao()
        {
            //Ação
            Funcionario funcionarioResultado = _funcionarioService.Obter(999999999);

            //Verificar
            funcionarioResultado.Should().BeNull();
        }

        [Test]
        public void FuncionarioIntegracaoSistema_ObterTudo_DeveSerValido()
        {
            //Cenário
            IEnumerable<Funcionario> listaFuncionario;

            //Ação
            listaFuncionario = _funcionarioService.ObterTudo();

            //Verificar
            listaFuncionario.Should().NotBeNull();
            listaFuncionario.Count().Should().BeGreaterOrEqualTo(0);
        }
    }
}
