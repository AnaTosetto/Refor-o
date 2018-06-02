using FluentAssertions;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Salas;
using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using SalaDeReuniao.Dominio.Funcionalidades.Salas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Testes.Funcionalidades.Salas
{
    [TestFixture]
    public class SalaTeste
    {
        [Test]
        public void Sala_DeveSerValido()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 1;

            //Ação
            Action acaoResultado = () => sala.Validar();

            //Verificar
            acaoResultado.Should().NotThrow<Exception>();
        }

        [Test]
        public void Sala_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaInvalida_NomeNuloOuVazio();
            sala.Id = 1;

            //Ação
            Action acaoResultado = () => sala.Validar();

            //Verificar
            acaoResultado.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void Sala_LugarIgualAZerio_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaInvalida_LugarIgualAZero();
            sala.Id = 1;

            //Ação
            Action acaoResultado = () => sala.Validar();

            //Verificar
            acaoResultado.Should().Throw<LugarIgualAZeroException>();
        }
    }
}
