using FluentAssertions;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Base.Salas;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Salas;
using SalaDeReuniao.Dominio.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using SalaDeReuniao.Infra.Data.Funcionalidades.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Infra.Data.Testes.Funcionalidades.Salas
{
    public class SalaRepositorioTeste
    {
        SalaRepositorio _salaRepositorio;

        [SetUp]
        public void Inicializar()
        {
            BaseSqlTeste.SeedDatabase();
            _salaRepositorio = new SalaRepositorio();
        }

        [Test]
        public void SalaRepositorio_Adicionar_DeveSerValido()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 0;

            //Ação
            sala = _salaRepositorio.Adicionar(sala);

            //Verificar
            sala.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void SalaRepositorio_Atualizar_DeveSerValido()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 1;

            //Ação
            sala = _salaRepositorio.Atualizar(sala);

            //Verificar
            sala.Id.Should().Be(sala.Id);
        }

        [Test]
        public void SalaRepositorio_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 0;

            //Ação
            Action acaoResultado = () => _salaRepositorio.Atualizar(sala);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void SalaRepositorio_Excluir_DeveSerValido()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 1;

            //Ação
            _salaRepositorio.Excluir(sala);
        }

        [Test]
        public void SalaRepositorio_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 0;

            //Ação
            Action acaoResultado = () => _salaRepositorio.Excluir(sala);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void SalaRepositorio_Obter_DeveSerValido()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;

            //Ação
            sala = _salaRepositorio.Obter(sala.Id);
        }

        [Test]
        public void SalaRepositorio_Obter_DeveRetornarExcecao()
        {
            //Cenário 
            Sala sala = new Sala();
            sala.Id = 0;

            //Ação
            Action acaoResultado = () => _salaRepositorio.Obter(sala.Id);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void SalaRepositorio_ObterTudo_DeveSerValido()
        {
            //Cenário
            IEnumerable<Sala> listaSala;

            //Ação
            listaSala = _salaRepositorio.ObterTudo();

            //Verificar
            listaSala.Should().NotBeNull();
            listaSala.First<Sala>().Id.Should().Be(1);
        }
    }
}
