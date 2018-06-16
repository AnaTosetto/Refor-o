using Pizzaria.Dominio.Enum;
using Pizzaria.Dominio.Funcionalidades.Entregas.Excecoes;
using Pizzaria.Dominio.Funcionalidades.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Funcionalidades.Entregas
{
    public class Entrega
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public Pizza Pizza { get; set; }
        public TipoEntregaEnum Entregar { get; set; }
        public double ValorTotal { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(NomeCliente))
                throw new NomeClienteNuloOuVazioExcecao();

            if (ValorTotal < 1)
                throw new ValorTotalMenorQueUmExcecao();

            if (Pizza == null)
                throw new SemPizzaExcecao();
        }

        public void CalcularValorTotal()
        {
            double TaxaEntrega;

            if(Entregar == TipoEntregaEnum.EMCASA)
            {
                TaxaEntrega = 4.50;
            }
            else
            {
                TaxaEntrega = 0;
            }

            ValorTotal = Pizza.Custo + TaxaEntrega;
        }
    }
}
