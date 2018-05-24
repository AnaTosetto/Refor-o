using Prova2.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Comum.Testes.Base.Livros
{
    public static class BaseSqlTeste
    {
        private const string RECREATE_LIVRO_TABLE ="TRUNCATE TABLE Emprestimo; DELETE FROM Livro DBCC CHECKIDENT('DBProva2.dbo.Livro', RESEED, 0)";

        private const string INSERT_LIVRO = "INSERT INTO Livro(Titulo, Tema, Autor, Volume, DataPublicacao, Disponibilidade) VALUES ('Titulo', 'Tema', 'Autor', 1, GETDATE(), 1 )";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_LIVRO_TABLE);
            Db.Update(INSERT_LIVRO);
        }
    }
}
