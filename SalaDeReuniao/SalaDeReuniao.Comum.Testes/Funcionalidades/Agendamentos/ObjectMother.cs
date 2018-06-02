using SalaDeReuniao.Dominio.Funcionalidades.Agendamentos;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Comum.Testes.Funcionalidades.Agendamentos
{
    public static partial class ObjectMother
    {
        public static Agendamento ObterAgendamentoValido()
        {
            return new Agendamento
            {
                HoraInicial = DateTime.Now.AddHours(2),
                HoraFinal = DateTime.Now.AddHours(4)
            };
        }

        public static Agendamento ObterAgendamentoInvalido_HoraInicialInvalida()
        {
            return new Agendamento
            {
                HoraInicial = DateTime.Now.AddHours(-2),
                HoraFinal = DateTime.Now.AddHours(4)
            };
        }

        public static Agendamento ObterAgendamentoInvalido_HoraFinalInvalida()
        {
            return new Agendamento
            {
                HoraInicial = DateTime.Now.AddHours(2),
                HoraFinal = DateTime.Now.AddHours(-4)
            };
        }

        public static Agendamento ObterAgendamentoInvalido_HoraFinalMenorQueHoraInicial()
        {
            return new Agendamento
            {
                HoraInicial = DateTime.Now.AddHours(2),
                HoraFinal = DateTime.Now.AddHours(1)
            };
        }

        public static Agendamento ObterAgendamentoInvalido_FuncionarioNulo()
        {
            return new Agendamento
            {
                HoraInicial = DateTime.Now.AddHours(2),
                HoraFinal = DateTime.Now.AddHours(4),
                Funcionario = null
            };
        }

        public static Agendamento ObterAgendamentoInvalido_SalaVazia()
        {
            return new Agendamento
            {
                HoraInicial = DateTime.Now.AddHours(2),
                HoraFinal = DateTime.Now.AddHours(4),
                Sala = null
            };
        }
    }
}
