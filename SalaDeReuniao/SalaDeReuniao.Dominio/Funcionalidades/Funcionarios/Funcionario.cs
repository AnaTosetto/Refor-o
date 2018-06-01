using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Funcionarios
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Ramal { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new NomeNuloOuVazioException();
            if (string.IsNullOrEmpty(Cargo))
                throw new CargoNuloOuVazioException();
            if (string.IsNullOrEmpty(Ramal))
                throw new RamalNuloOuVazioException();
        }
    }
}
