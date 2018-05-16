using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Produtos.Exceptions;
using System;

namespace DonaLaura.Dominio.Features.Produtos
{
    public class Produto
    {
        public long Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual double PrecoVenda { get; set; }
        public virtual double PrecoCusto { get; set; }
        public virtual bool Disponibilidade { get; set; }
        public virtual DateTime DataFabricacao { get; set; }
        public virtual DateTime DataValidade { get; set; }
       

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
            if (DataFabricacao > DateTime.Now)
                throw new DataDeFabricacaoInvalidaException();
        }
    }
}
