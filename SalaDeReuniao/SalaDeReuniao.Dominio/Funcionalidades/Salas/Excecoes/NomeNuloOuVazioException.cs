using SalaDeReuniao.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Salas.Excecoes
{
    public class NomeNuloOuVazioException : ExcecaoDeNegocio
    {
        public NomeNuloOuVazioException() : base("O nome da sala não pode ser nulo.")
        {
        }
    }
}
