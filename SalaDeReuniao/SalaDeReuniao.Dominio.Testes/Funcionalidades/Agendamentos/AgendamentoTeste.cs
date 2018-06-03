using FluentAssertions;
using Moq;
using NUnit.Framework;
using SalaDeReuniao.Comum.Testes.Funcionalidades.Agendamentos;
using SalaDeReuniao.Dominio.Funcionalidades.Agendamentos;
using SalaDeReuniao.Dominio.Funcionalidades.Agendamentos.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Testes.Funcionalidades.Agendamentos
{
    public class AgendamentoTeste
    {
        private Mock<Funcionario> _mockFuncionario;
        private Mock<Sala> _mockSala;

        [SetUp]
        public void TestSetup()
        {
            _mockFuncionario = new Mock<Funcionario>();
            _mockSala = new Mock<Sala>();
        }

        [Test]
        public void Agendamento_DeveSerValido()
        {
            //Cenário
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 1;
            agendamento.Funcionario = _mockFuncionario.Object;
            agendamento.Sala = _mockSala.Object;

            _mockSala.Setup(sala => sala.Disponibilidade).Returns(true);

            //Ação
            Action acaoResultado = agendamento.Validar;

            //Verificar
            acaoResultado.Should().NotThrow<Exception>();
        }

        [Test]
        public void Agendamento_SalaIndisponivelParaAgendamento_DeveRetornarExcecao()
        {
            //Cenário
            Agendamento agendamento = ObjectMother.ObterAgendamentoValido();
            agendamento.Id = 1;
            agendamento.Sala = _mockSala.Object;
            agendamento.Funcionario = _mockFuncionario.Object;

            _mockSala.Setup(sala => sala.Disponibilidade).Returns(false);
            //_mockLivro.Object.Disponibilidade = false;

            //Ação
            Action acaoResultado = () => agendamento.Validar();

            //Verificar
            acaoResultado.Should().Throw<SalaIndisponivelException>();
        }

        [Test]
        public void Agendamento_HoraInicialInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Agendamento agendamento = ObjectMother.ObterAgendamentoInvalido_HoraInicialInvalida();
            agendamento.Id = 1;
            agendamento.Funcionario = _mockFuncionario.Object;
            agendamento.Sala = _mockSala.Object;

            //Ação
            Action acaoResultado = () => agendamento.Validar();

            //Verificar
            acaoResultado.Should().Throw<HoraInicialInvalidaException>();
        }

        [Test]
        public void Agendamento_HoraFinalInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Agendamento agendamento = ObjectMother.ObterAgendamentoInvalido_HoraFinalInvalida();
            agendamento.Id = 1;
            agendamento.Funcionario = _mockFuncionario.Object;
            agendamento.Sala = _mockSala.Object;

            //Ação
            Action acaoResultado = () => agendamento.Validar();

            //Verificar
            acaoResultado.Should().Throw<HoraFinalInvalidaException>();
        }

        [Test]
        public void Agendamento_HoraFinalMenorQueHoraInicial_DeveRetornarExcecao()
        {
            //Cenário
            Agendamento agendamento = ObjectMother.ObterAgendamentoInvalido_HoraFinalMenorQueHoraInicial();
            agendamento.Id = 1;
            agendamento.Funcionario = _mockFuncionario.Object;
            agendamento.Sala = _mockSala.Object;

            //Ação
            Action acaoResultado = () => agendamento.Validar();

            //Verificar
            acaoResultado.Should().Throw<HoraFinalMenorQueHoraInicialException>();
        }

        [Test]
        public void Agendamento_FuncionarioNulo_DeveRetornarExcecao()
        {
            //Cenário
            Agendamento agendamento = ObjectMother.ObterAgendamentoInvalido_FuncionarioNulo();
            agendamento.Id = 1;
            agendamento.Sala = _mockSala.Object;

            //Ação
            Action acaoResultado = () => agendamento.Validar();

            //Verificar
            acaoResultado.Should().Throw<FuncionarioNuloException>();
        }

        [Test]
        public void Agendamento_SalaVazia_DeveRetornarExcecao()
        {
            //Cenário
            Agendamento agendamento = ObjectMother.ObterAgendamentoInvalido_SalaVazia();
            agendamento.Id = 1;
            agendamento.Funcionario = _mockFuncionario.Object;

            //Ação
            Action acaoResultado = () => agendamento.Validar();

            //Verificar
            acaoResultado.Should().Throw<SalaNulaOuVaziaException>();
        }
    }
}
