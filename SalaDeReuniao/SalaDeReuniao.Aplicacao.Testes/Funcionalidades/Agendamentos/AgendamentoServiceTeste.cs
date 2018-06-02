using Moq;
using NUnit.Framework;
using SalaDeReuniao.Dominio.Funcionalidades.Agendamentos;
using SalaDeReuniao.Funcionalidades.Agendamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Aplicacao.Testes.Funcionalidades.Agendamentos
{
    public class AgendamentoServiceTeste
    {
        AgendamentoService _agendamentoService;

        private Mock<IAgendamentoRepositorio> _mockAgendamentoRepositorio;

        [SetUp]
        public void Inicializar()
        {
            _mockAgendamentoRepositorio = new Mock<IAgendamentoRepositorio>();
            _agendamentoService = new AgendamentoService(_mockAgendamentoRepositorio.Object);
        }
    }
}
