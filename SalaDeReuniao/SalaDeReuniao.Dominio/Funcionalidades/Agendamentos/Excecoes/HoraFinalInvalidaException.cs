using SalaDeReuniao.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Agendamentos.Excecoes
{
    public class HoraFinalInvalidaException : ExcecaoDeNegocio
    {
        public HoraFinalInvalidaException() : base("Para agendar a hora final precisa ser maior que a hora atual.")
        {
        }
    }
}
