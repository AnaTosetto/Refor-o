using DonaLaura.Domain.Features.Produtos.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double PrecoVenda { get; set; }
        public double PrecoCusto { get; set; }
        public bool Disponibilidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
       

        public void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new NomeNuloOuVazioException();
            if (Nome.Length < 4)
                throw new CaracteresMinimoException();
            if (DataValidade < DataFabricacao)
                throw new DataDeValidadeInvalidaException();
            if (PrecoCusto > PrecoVenda)
                throw new PrecoDeCustoInvalidoException();
        }
    }
}
