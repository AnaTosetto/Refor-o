using SalaDeReuniao.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Agendamentos.Excecoes
{
    public class HoraFinalMenorQueHoraInicialException : ExcecaoDeNegocio
    {
        public HoraFinalMenorQueHoraInicialException() : base("A hora final deve ser maior que a hora inicial.")
        {
        }
    }
}
