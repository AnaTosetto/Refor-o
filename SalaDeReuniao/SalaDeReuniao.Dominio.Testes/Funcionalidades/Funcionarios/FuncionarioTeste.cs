using FluentAssertions;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Testes.Funcionalidades.Funcionarios
{
    [TestFixture]
    public class FuncionarioTeste
    {
        [Test]
        public void Funcionario_DeveSerValido()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioValido();
            funcionario.Id = 1;

            //Ação
            Action acaoResultado = () => funcionario.Validar();

            //Verificar
            acaoResultado.Should().NotThrow();
        }

        [Test]
        public void Funcionario_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioInvalido_NomeNuloOuVazio();
            funcionario.Id = 1;

            //Ação
            Action acaoResultado = () => funcionario.Validar();

            //Verificar
            acaoResultado.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void Funcionario_CargoNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioInvalido_CargoNuloOuVazio();
            funcionario.Id = 1;

            //Ação
            Action acaoResultado = () => funcionario.Validar();

            //Verificar
            acaoResultado.Should().Throw<CargoNuloOuVazioException>();
        }

        [Test]
        public void Funcionario_RamalNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = ObjectMother.ObterFuncionarioInvalido_RamalNuloOuVazio();
            funcionario.Id = 1;

            //Ação
            Action acaoResultado = () => funcionario.Validar();

            //Verificar
            acaoResultado.Should().Throw<RamalNuloOuVazioException>();
        }
    }
}
