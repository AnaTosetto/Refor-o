using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Comum.Testes.Funcionalidades.Funcionarios
{
    public static partial class ObjectMother
    {
        public static Funcionario ObterFuncionarioValido()
        {
            return new Funcionario
            {
                Nome = "nome",
                Cargo = "cargo",
                Ramal = "ramal"
            };
        }

        public static Funcionario ObterFuncionarioInvalido_NomeNuloOuVazio()
        {
            return new Funcionario
            {
                Nome = "",
                Cargo = "cargo",
                Ramal = "ramal"
            };
        }

        public static Funcionario ObterFuncionarioInvalido_CargoNuloOuVazio()
        {
            return new Funcionario
            {
                Nome = "nome",
                Cargo = "",
                Ramal = "ramal"
            };
        }

        public static Funcionario ObterFuncionarioInvalido_RamalNuloOuVazio()
        {
            return new Funcionario
            {
                Nome = "nome",
                Cargo = "cargo",
                Ramal = ""
            };
        }
    }

}
