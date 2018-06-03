using FluentAssertions;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Agendamentos;
using SalaDeReuniao.Dominio.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Agendamentos;
using SalaDeReuniao.Dominio.Funcionalidades.Agendamentos.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using SalaDeReuniao.Funcionalidades.Agendamentos;
using SalaDeReuniao.Infra.Data.Funcionalidades.Agendamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Integracao.Testes.Funcionalidades.Agendamentos
{
    public class AgendamentoIntegracaoSistema
    {
        AgendamentoRepositorio _agendamentoRepositorio = new AgendamentoRepositorio();

        AgendamentoService _agendamentoService;

        [SetUp]
        public void TestSetup()
        {
            _agendamentoService = new AgendamentoService(_agendamentoRepositorio);
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Adicionar_DeveSerValido()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = true;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 0;
            agendamento.Sala = sala;
            agendamento.Funcionario = funcionario;

            //Ação
            Agendamento agendamentoResultado = _agendamentoService.Adicionar(agendamento);

            //Verificar
            agendamentoResultado.Should().NotBeNull();
            agendamentoResultado.Id.Should().BeGreaterThan(0);
            agendamentoResultado.Sala.Should().Be(agendamento.Sala);
            agendamentoResultado.Funcionario.Should().Be(agendamento.Funcionario);
            agendamentoResultado.HoraInicial.Should().BeBefore(DateTime.Now.AddDays(1));
            agendamentoResultado.HoraFinal.Should().BeBefore(DateTime.Now.AddDays(2));

            Agendamento agendamentoGet = _agendamentoService.Obter(agendamentoResultado.Id);
            agendamentoResultado.Id.Should().Be(agendamentoGet.Id);

            _agendamentoService.Excluir(agendamentoResultado);
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Adicionar_HoraInicialInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = true;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoInvalido_HoraInicialInvalida();
            agendamento.Id = 0;
            agendamento.Sala = sala;
            agendamento.Funcionario = funcionario;

            //Ação
            Action acaoResultado = () => _agendamentoService.Adicionar(agendamento);

            //Verificar
            acaoResultado.Should().Throw<HoraInicialInvalidaException>();
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Adicionar_HoraFinalInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = false;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoInvalido_HoraFinalInvalida();
            agendamento.Id = 0;
            agendamento.Sala = sala;
            agendamento.Funcionario = funcionario;

            //Ação
            Action acaoResultado = () => _agendamentoService.Adicionar(agendamento);

            //Verificar
            acaoResultado.Should().Throw<HoraFinalInvalidaException>();
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Adicionar_HoraFinalMenorQueHoraInicial_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = false;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoInvalido_HoraFinalMenorQueHoraInicial();
            agendamento.Id = 0;
            agendamento.Sala = sala;
            agendamento.Funcionario = funcionario;

            //Ação
            Action acaoResultado = () => _agendamentoService.Adicionar(agendamento);

            //Verificar
            acaoResultado.Should().Throw<HoraFinalMenorQueHoraInicialException>();
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Adicionar_FuncionarioNulo_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = false;
            Agendamento agendamento = ObjectMother.ObterAgendamentoInvalido_FuncionarioNulo();
            agendamento.Id = 0;
            agendamento.Sala = sala;

            //Ação
            Action acaoResultado = () => _agendamentoService.Adicionar(agendamento);

            //Verificar
            acaoResultado.Should().Throw<FuncionarioNuloException>();
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Adicionar_SalaNulaOuVazia_DeveRetornarExcecao()
        {
            //Cenário
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoInvalido_SalaVazia();
            agendamento.Id = 0;
            agendamento.Funcionario = funcionario;

            //Ação
            Action acaoResultado = () => _agendamentoService.Adicionar(agendamento);

            //Verificar
            acaoResultado.Should().Throw<SalaNulaOuVaziaException>();
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Atualizar_DeveSerValido()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 0;
            agendamento.Sala = sala;
            agendamento.Sala.Disponibilidade = true;
            agendamento.Funcionario = funcionario;

            agendamento = _agendamentoService.Adicionar(agendamento);

            _agendamentoService.Obter(agendamento.Id);

            DateTime horaInicialAntiga = agendamento.HoraInicial;
            DateTime horaInicialNova = DateTime.Now.AddHours(2);

            if (horaInicialAntiga == horaInicialNova)
            {
                horaInicialNova = DateTime.Now.AddHours(1);
            }

            agendamento.HoraInicial = horaInicialNova;

            //Ação
            Agendamento agendamentoResultado = _agendamentoService.Atualizar(agendamento);

            //Verificar
            agendamentoResultado.HoraInicial.Should().NotBe(horaInicialAntiga);
            agendamentoResultado.Id.Should().Be(agendamento.Id);
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = true;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 0;
            agendamento.Sala = sala;
            agendamento.Funcionario = funcionario;

            //Ação
            Action acaoResultado = () => _agendamentoService.Atualizar(agendamento);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Excluir_DeveSerValido()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = true;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 0;
            agendamento.Sala = sala;
            agendamento.Funcionario = funcionario;

            agendamento = _agendamentoService.Adicionar(agendamento);

            //Ação
            _agendamentoService.Excluir(agendamento);

            //Verificar
            Agendamento agendamentoInexistente = _agendamentoService.Obter(agendamento.Id);
            agendamentoInexistente.Should().BeNull();
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = true;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 0;
            agendamento.Sala = sala;
            agendamento.Funcionario = funcionario;

            //Ação
            Action acaoResultado = () => _agendamentoService.Excluir(agendamento);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Obter_DeveSerValido()
        {
            //Cenário
            Sala sala = new Sala();
            sala.Id = 1;
            sala.Disponibilidade = true;
            Funcionario funcionario = new Funcionario();
            funcionario.Id = 1;

            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 0;
            agendamento.Sala = sala;
            agendamento.Funcionario = funcionario;

            agendamento = _agendamentoService.Adicionar(agendamento);

            //Ação
            agendamento = _agendamentoService.Obter(agendamento.Id);

            //Verificar
            agendamento.Id.Should().Be(agendamento.Id);
            agendamento.Should().NotBeNull();
        }

        [Test]
        public void AgendamentoIntegracaoSistema_Obter_DeveRetornarExcecao()
        {
            //Ação
            Agendamento agendamentoResultado = _agendamentoService.Obter(999999999);

            //Verificar
            agendamentoResultado.Should().BeNull();
        }

        [Test]
        public void AgendamentoIntegracaoSistema_ObterTudo_DeveSerValido()
        {
            //Cenário
            IEnumerable<Agendamento> listaAgendamento;

            //Ação
            listaAgendamento = _agendamentoService.ObterTudo();

            //Verificar
            listaAgendamento.Should().NotBeNull();
            listaAgendamento.Count().Should().BeGreaterOrEqualTo(0);
        }
    }
}
