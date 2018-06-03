using FluentAssertions;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Base.Agendamentos;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Agendamentos;
using SalaDeReuniao.Dominio.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Agendamentos;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using SalaDeReuniao.Infra.Data.Funcionalidades.Agendamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Infra.Data.Testes.Funcionalidades.Agendamentos
{
    public class AgendamentoRepositorioTeste
    {
        AgendamentoRepositorio _agendamentoRepositorio;

        [SetUp]
        public void Inicializar()
        {
            BaseSqlTeste.SeedDatabase();
            _agendamentoRepositorio = new AgendamentoRepositorio();
        }

        [Test]
        public void AgendamentoRepositorio_Adicionar_DeveSerValido()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = true;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 0;
            agendamento.Funcionario = funcionario;
            agendamento.Sala = sala;

            //Ação
            agendamento = _agendamentoRepositorio.Adicionar(agendamento);

            //Verificar
            agendamento.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void AgendamentoRepositorio_Atualizar_DeveSerValido()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = true;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 1;
            agendamento.Funcionario = funcionario;
            agendamento.Sala = sala;

            //Ação
            agendamento = _agendamentoRepositorio.Atualizar(agendamento);

            //Verificar
            agendamento.Id.Should().Be(agendamento.Id);
        }

        [Test]
        public void AgendamentoRepositorio_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = true;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 0;
            agendamento.Funcionario = funcionario;
            agendamento.Sala = sala;

            //Ação
            Action acaoResultado = () => _agendamentoRepositorio.Atualizar(agendamento);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void AgendamentoRepositorio_Excluir_DeveSerValido()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 1;
            agendamento.Funcionario = funcionario;
            agendamento.Sala = sala;

            //Ação
            _agendamentoRepositorio.Excluir(agendamento);
        }

        [Test]
        public void AgendamentoRepositorio_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 0;
            agendamento.Funcionario = funcionario;
            agendamento.Sala = sala;

            //Ação
            Action acaoResultado = () => _agendamentoRepositorio.Excluir(agendamento);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void AgendamentoRepositorio_Obter_DeveSerValido()
        {
            //Cenário
            Agendamento agendamento = new Agendamento();
            agendamento.Id = 1;

            //Ação
            agendamento = _agendamentoRepositorio.Obter(agendamento.Id);
        }

        [Test]
        public void AgendamentoRepositorio_Obter_DeveRetornarExcecao()
        {
            //Cenário
            Agendamento agendamento = new Agendamento();
            agendamento.Id = 0;

            //Ação
            Action acaoResultado = () => _agendamentoRepositorio.Obter(agendamento.Id);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void AgendamentoRepositorio_ObterTudo_DeveSerValido()
        {
            //Cenário
            IEnumerable<Agendamento> listaAgendamento;

            //Ação
            listaAgendamento = _agendamentoRepositorio.ObterTudo();

            //Verificar
            listaAgendamento.Should().NotBeNull();
            listaAgendamento.First<Agendamento>().Id.Should().Be(1);
        }
    }
}
