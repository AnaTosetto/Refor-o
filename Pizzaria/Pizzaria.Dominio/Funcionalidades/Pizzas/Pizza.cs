using Pizzaria.Dominio.Enum;
using Pizzaria.Dominio.Funcionalidades.Pizzas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Funcionalidades.Pizzas
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ingredientes { get; set; }
        public TipoEnum Tipo { get; set; }
        public DateTime DataFabricacao { get; set; }
        public int QuantidadeFatias { get; set; }
        public double Custo { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new NomeNuloOuVazioExcecao();

            if (Nome.Length < 6)
                throw new NomeComMinimoDeCaracteresExcecao();

            if (string.IsNullOrEmpty(Ingredientes))
                throw new SemIngredientesExcecao();

            if (QuantidadeFatias < 1)
                throw new QuantidadeDeFatiasMenorQueUmExcecao();
        }
    }
}
