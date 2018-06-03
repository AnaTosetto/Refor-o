using FluentAssertions;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Salas;
using SalaDeReuniao.Dominio.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using SalaDeReuniao.Dominio.Funcionalidades.Salas.Excecoes;
using SalaDeReuniao.Funcionalidades.Salas;
using SalaDeReuniao.Infra.Data.Funcionalidades.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Integracao.Testes.Funcionalidades.Salas
{
    public class SalaIntegracaoSistema
    {
        SalaRepositorio _salaRepositorio = new SalaRepositorio();

        SalaService _salaService;

        [SetUp]
        public void Inicializar()
        {
            _salaService = new SalaService(_salaRepositorio);
        }

        [Test]
        public void SalaIntegracaoSistema_Adicionar_DeveSerValido()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 0;

            //Ação
            Sala salaResultado = _salaService.Adicionar(sala);

            //Verificar
            salaResultado.Should().NotBeNull();
            salaResultado.Id.Should().BeGreaterThan(0);
            salaResultado.Nome.Should().Be(sala.Nome);
            salaResultado.Lugar.Should().Be(sala.Lugar);

            Sala salaGet = _salaService.Obter(salaResultado.Id);
            salaResultado.Id.Should().Be(salaGet.Id);

            _salaService.Excluir(salaResultado);
        }

        [Test]
        public void SalaIntegracaoSistema_Adicionar_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaInvalida_NomeNuloOuVazio();
            sala.Id = 0;

            //Ação
            Action acaoResultado = () => _salaService.Adicionar(sala);

            //Verificar
            acaoResultado.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void SalaIntegracaoSistema_Atualizar_DeveSerValido()
        {
            //Cenário
            Sala salaParaEditar = _salaService.Obter(1);
            salaParaEditar.Id = 1;
            string nomeAntigo = salaParaEditar.Nome;
            string nomeNovo = "Nome";

            if (nomeAntigo == nomeNovo)
            {
                nomeNovo = "Nome novo";
            }

            salaParaEditar.Nome = nomeNovo;

            //Ação
            Sala salaResultado = _salaService.Atualizar(salaParaEditar);

            //Verificar
            salaResultado.Nome.Should().NotBe(nomeAntigo);
            salaResultado.Id.Should().Be(salaParaEditar.Id);
        }

        [Test]
        public void SalaIntegracaoSistema_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 0;

            //Ação
            Action acaoResultado = () => _salaService.Atualizar(sala);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void SalaIntegracaoSistema_Excluir_DeveSerValido()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 0;

            sala = _salaService.Adicionar(sala);

            //Ação
            _salaService.Excluir(sala);

            //Verificar
            Sala salaInexistente = _salaService.Obter(sala.Id);
            salaInexistente.Should().BeNull();
        }

        [Test]
        public void SalaIntegracaoSistema_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = ObjectMother.ObterSalaValida();
            sala.Id = 0;

            //Ação
            Action acaoResultado = () => _salaService.Excluir(sala);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void SalaintegracaoSistema_Obter_DeveSerValido()
        {
            //Ação
            Sala sala = _salaService.Obter(1);

            //Verificar
            sala.Id.Should().Be(1);
            sala.Should().NotBeNull();
        }

        [Test]
        public void SalaIntegracaoSistema_Obter_DeveRetornarExcecao()
        {
            //Ação
            Sala salaResultado = _salaService.Obter(999999999);

            //Verificar
            salaResultado.Should().BeNull();
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
