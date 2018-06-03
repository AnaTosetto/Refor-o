using FluentAssertions;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Base.Funcionarios;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using SalaDeReuniao.Infra.Data.Funcionalidades.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Infra.Data.Testes.Funcionalidades.Funcionarios
{
    [TestFixture]
    public class FuncionarioRepositorioTeste
    {
        FuncionarioRepositorio _funcionarioRepositorio;

        [SetUp]
        public void Inicializar()
        {
            BaseSqlTeste.SeedDatabase();
            _funcionarioRepositorio = new FuncionarioRepositorio();
        }


        public void FuncionarioRepositorio_Adicionar_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 0;

            //Ação
            funcionario = _funcionarioRepositorio.Adicionar(funcionario);

            //Verificar
            funcionario.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void FuncionarioRepositorio_Atualizar_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 1;

            //Ação
            funcionario = _funcionarioRepositorio.Atualizar(funcionario);

            //Verificar
            funcionario.Id.Should().Be(funcionario.Id);
        }

        [Test]
        public void FuncionarioRepositorio_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 0;

            //Ação
            Action acaoResultado = () => _funcionarioRepositorio.Atualizar(funcionario);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void FuncionarioRepositorio_Excluir_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 1;

            //Ação
            _funcionarioRepositorio.Excluir(funcionario);
        }

        [Test]
        public void FuncionarioRepositorio_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 0;

            //Ação
            Action acaoResultado = () => _funcionarioRepositorio.Excluir(funcionario);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void FuncionarioRepositorio_Obter_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;

            //Ação
            funcionario = _funcionarioRepositorio.Obter(funcionario.Id);
        }

        [Test]
        public void FuncionarioRepositorio_Obter_DeveRetornarExcecao()
        {
            //Cenário 
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 0;

            //Ação
            Action acaoResultado = () => _funcionarioRepositorio.Obter(funcionario.Id);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void FuncionarioRepositorio_ObterTudo_DeveSerValido()
        {
            //Cenário
            IEnumerable<Funcionario> listaFuncionario;

            //Ação
            listaFuncionario = _funcionarioRepositorio.ObterTudo();

            //Verificar
            listaFuncionario.Should().NotBeNull();
            listaFuncionario.First<Funcionario>().Id.Should().Be(1);
        }
    }
}
