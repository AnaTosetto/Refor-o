using SalaDeReuniao.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Agendamentos.Excecoes
{
    public class SalaVaziaException : ExcecaoDeNegocio
    {
        public SalaVaziaException() : base("Para agendar sala não pode ser nulo ou vazio.")
        {
        }
    }
}
