using SalaDeReuniao.Dominio.Funcionalidades.Agendamentos.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Agendamentos
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public Funcionario Funcionario { get; set; }
        public Sala Sala { get; set; }

        public void Validar()
        {
            if (HoraInicial.Hour == DateTime.Now.AddHours(-2).Hour)
                throw new HoraInicialInvalidaException();

            if (HoraFinal.Hour == DateTime.Now.AddHours(-4).Hour)
                throw new HoraFinalInvalidaException();

            if (HoraFinal.Hour < HoraInicial.Hour)
                throw new HoraFinalMenorQueHoraInicialException();
            if (Funcionario == null)
                throw new FuncionarioNuloException();
            if (Sala == null)
                throw new SalaVaziaException();
        }
    }
}
