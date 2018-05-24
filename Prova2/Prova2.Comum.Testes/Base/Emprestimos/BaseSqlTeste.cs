using Prova2.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Comum.Testes.Base.Emprestimos
{
    public static class BaseSqlTeste
    {
        private const string INSERT_EMPRESTIMO = "INSERT INTO Emprestimo(NomeCliente, LivroId, DataDevolucao) VALUES ('nome', 1, GETDATE())";

        public static void SeedDatabase()
        {
            Livros.BaseSqlTeste.SeedDatabase();
            Db.Update(INSERT_EMPRESTIMO);
        }
    }
}
