using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Comum.Testes.Funcionalidades.Salas
{
    public static partial class ObjectMother
    {
        public static Sala ObterSalaValida()
        {
            return new Sala
            {
                Nome = "nome da sala",
                Lugar = 2
            };
        }

        public static Sala ObterSalaInvalida_NomeNuloOuVazio()
        {
            return new Sala
            {
                Nome = "",
                Lugar = 2
            };
        }

        public static Sala ObterSalaInvalida_LugarIgualAZero()
        {
            return new Sala
            {
                Nome = "nome da sala",
                Lugar = 0
            };
        }
    }
}
