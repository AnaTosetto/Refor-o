using SalaDeReuniao.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Agendamentos.Excecoes
{
    public class SalaIndisponivelException : ExcecaoDeNegocio
    {
        public SalaIndisponivelException() : base("Sala está indisponível para agendamento.")
        {  
        }
    }
}
