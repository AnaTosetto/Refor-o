using SalaDeReuniao.Dominio.Funcionalidades.Agendamentos;
using SalaDeReuniao.Funcionalidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Funcionalidades.Agendamentos
{
    public class AgendamentoService : IService<Agendamento>
    {
        IAgendamentoRepositorio _agendamentoRepositorio;

        public AgendamentoService(IAgendamentoRepositorio agendamentoRepositorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
        }

        public Agendamento Adicionar(Agendamento agendamento)
        {
            agendamento.Validar();

            return _agendamentoRepositorio.Adicionar(agendamento);
        }

        public Agendamento Atualizar(Agendamento agendamento)
        {
            agendamento.Validar();

            return _agendamentoRepositorio.Atualizar(agendamento);
        }

        public void Excluir(Agendamento agendamento)
        {
            _agendamentoRepositorio.Excluir(agendamento);
        }

        public Agendamento Obter(int id)
        {
            return _agendamentoRepositorio.Obter(id);
        }

        public IEnumerable<Agendamento> ObterTudo()
        {
            return _agendamentoRepositorio.ObterTudo();
        }
    }
}
