using SalaDeReuniao.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Agendamentos.Excecoes
{
    public class HoraInicialInvalidaException : ExcecaoDeNegocio
    {
        public HoraInicialInvalidaException() : base("Para agendar a hora inicial precisa ser maior que a hora atual.")
        {
        }
    }
}
