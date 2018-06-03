using FluentAssertions;
using Moq;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Salas;
using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using SalaDeReuniao.Dominio.Funcionalidades.Salas.Excecoes;
using SalaDeReuniao.Funcionalidades.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Aplicacao.Testes.Funcionalidades.Salas
{
    public class SalaServiceTeste
    {
        SalaService _salaService;

        private Mock<ISalaRepositorio> _mockSalaRepositorio;

        [SetUp]
        public void Inicializar()
        {
            _mockSalaRepositorio = new Mock<ISalaRepositorio>();
            _salaService = new SalaService(_mockSalaRepositorio.Object);
        }

        [Test]
        public void SalaService_Adicionar_DeveSerValido()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 0;

            _mockSalaRepositorio.Setup(rp => rp.Adicionar(sala)).Returns(new Sala { Id = 1, Nome = "nome sala", Lugar = 2, Disponibilidade = true });

            //Ação
            Sala retorno = _salaService.Adicionar(sala);

            //Verificar
            _mockSalaRepositorio.Verify(rp => rp.Adicionar(sala));
            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
            retorno.Id.Should().NotBe(sala.Id);
        }

        [Test]
        public void SalaService_Adicionar_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaInvalida_NomeNuloOuVazio();
            sala.Id = 0;

            _mockSalaRepositorio.Setup(rp => rp.Adicionar(sala)).Returns(new Sala { Id = 1, Nome = "nome sala", Lugar = 2, Disponibilidade = true });

            //Ação
            Action acaoResultado = () => _salaService.Adicionar(sala);

            //Verificar
            acaoResultado.Should().Throw<NomeNuloOuVazioException>();
            _mockSalaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void SalaService_Adicionar_LugarIgualAZerio_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaInvalida_LugarIgualAZero();
            sala.Id = 0;

            _mockSalaRepositorio.Setup(rp => rp.Adicionar(sala)).Returns(new Sala { Id = 1, Nome = "nome sala", Lugar = 2, Disponibilidade = true });

            //Ação
            Action acaoResultado = () => _salaService.Adicionar(sala);

            //Verificar
            acaoResultado.Should().Throw<LugarIgualAZeroException>();
            _mockSalaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void SalaService_Atualizar_DeveSerValido()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 1;

            _mockSalaRepositorio.Setup(rp => rp.Atualizar(sala)).Returns(new Sala { Id = sala.Id, Nome = "nome sala", Lugar = 2, Disponibilidade = true });

            //Ação
            Sala retorno = _salaService.Atualizar(sala);

            //Verificar
            _mockSalaRepositorio.Verify(rp => rp.Atualizar(sala));
            retorno.Should().NotBeNull();
            retorno.Id.Should().Be(sala.Id);
        }

        [Test]
        public void SalaService_Excluir_DeveSerValido()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 1;

            _mockSalaRepositorio.Setup(rp => rp.Excluir(sala));

            //Ação
            _salaService.Excluir(sala);

            //Verificar
            _mockSalaRepositorio.Verify(rp => rp.Excluir(sala));
        }

        [Test]
        public void SalaService_Obter_DeveSerValido()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 1;

            _mockSalaRepositorio.Setup(rp => rp.Obter(sala.Id)).Returns(new Sala { Id = 1, Nome = "nome sala", Lugar = 2, Disponibilidade = true });

            //Ação
            Sala retorno = _salaService.Obter(sala.Id);

            //Verificar
            _mockSalaRepositorio.Verify(rp => rp.Obter(sala.Id));

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void SalaService_ObterTudo_DeveSerValido()
        {
            //Cenário
            _mockSalaRepositorio.Setup(rp => rp.ObterTudo()).Returns(Enumerable.Empty<Sala>);

            //Ação
            IEnumerable<Sala> retorno = _salaService.ObterTudo();

            //Verificar
            foreach (Sala sala in retorno)
            {
                sala.Id.Should().BeGreaterThan(0);
                sala.Should().NotBeNull();
            }

            _mockSalaRepositorio.Verify(rp => rp.ObterTudo());
        }
    }
}
