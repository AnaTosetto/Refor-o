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
            throw new NotImplementedException();
        }

        public Agendamento Atualizar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public Agendamento Obter(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agendamento> ObterTudo()
        {
            throw new NotImplementedException();
        }
    }
}
