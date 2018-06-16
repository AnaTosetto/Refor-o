using Pizzaria.Dominio.Enum;
using Pizzaria.Dominio.Funcionalidades.Entregas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Comum.Testes.Funcionalidades.Entregas
{
    public static partial class ObjectMother
    {
        public static Entrega ObterEntregaValida()
        {
            return new Entrega()
            {
                NomeCliente = "Nome Cliente",
                Entregar = TipoEntregaEnum.NOBALCAO,
                ValorTotal = 10
            };
        }

        public static Entrega ObterEntregaValida_EntregaEmCasa()
        {
            return new Entrega()
            {
                NomeCliente = "Nome Cliente",
                Entregar = TipoEntregaEnum.EMCASA
            };
        }

        public static Entrega ObterEntregaInvalida_NomeClienteNuloOuVazio()
        {
            return new Entrega()
            {
                NomeCliente = "",
                Entregar = TipoEntregaEnum.NOBALCAO,
                ValorTotal = 10
            };
        }

        public static Entrega ObterEntregaInvalida_ValorTotalMenorQueUm()
        {
            return new Entrega()
            {
                NomeCliente = "Nome Cliente",
                Entregar = TipoEntregaEnum.NOBALCAO,
                ValorTotal = 0
            };
        }
    }
}
