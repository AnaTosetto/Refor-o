using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Dominio.Features.Emprestimos
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataDevolucao { get; set; }

        public void Validar()
        {

        }
    }
}
