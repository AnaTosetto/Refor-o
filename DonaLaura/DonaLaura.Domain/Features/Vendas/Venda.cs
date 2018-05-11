using DonaLaura.Domain.Features.Vendas.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Vendas
{
    public class Venda
    {
        public int Id { get; set; }
        public Produto produto { get; set; }
        public string NomeCliente { get; set; }
        public int Quantidade { get; set; }
        public double Lucro { get; set; }   
    }
}
