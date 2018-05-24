using Prova2.Dominio.Exceptions;
using Prova2.Dominio.Features.Livros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Infra.Data.Features.Livros
{
    public class LivroRepositorio : ILivroRepositorio
    {
        string _sqlInsert = @"INSERT INTO Livro
                                (Titulo, Tema, Autor, Volume, DataPublicacao, Disponibilidade)
                              VALUES
                                (@Titulo, @Tema, @Autor, @Volume, @DataPublicacao, @Disponibilidade);";

        string _sqlUpdate = @"UPDATE Livro
                                SET Titulo = @Titulo, Tema = @Tema, Autor = @Autor,
                                    Volume = @Volume, DataPublicacao = @DataPublicacao, 
                                    Disponibilidade = @Disponibilidade
                                WHERE Id = @Id";

        string _sqlDelete = @"DELETE FROM Livro 
                                WHERE Id = @Id";

        string _sqlGet = @"SELECT * FROM Livro
                            WHERE Id = @Id";

        string _sqlGetAll = @"SELECT * FROM Livro";

        public Livro Adicionar(Livro livro)
        {
            if(livro.Id == 0)
            {
                livro.Id = Db.Insert(_sqlInsert, Take(livro));
                return livro;
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }      
        }

        public Livro Atualizar(Livro livro)
        {
            if(livro.Id > 0)
            {
                Db.Update(_sqlUpdate, Take(livro));
                return livro;
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public void Excluir(Livro livro)
        {
            if(livro.Id > 0)
            {
                Db.Delete(_sqlDelete, Take(livro));
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public Livro Obter(int id)
        {
            if(id > 0)
            {
                return Db.Get(_sqlGet, Make, new object[] { "@Id", id });
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public IEnumerable<Livro> ObterTudo()
        {
            return Db.GetAll<Livro>(_sqlGetAll, Make);
        }

        private object[] Take(Livro livro)
        {
            return new object[]
            {
                "@Id", livro.Id,
                "@Titulo", livro.Titulo,
                "@Tema", livro.Tema,
                "@Autor", livro.Autor,
                "@Volume", livro.Volume,
                "@DataPublicacao", livro.DataPublicacao,
                "@Disponibilidade", livro.Disponibilidade
            };
        }

        private static Func<IDataReader, Livro> Make = reader =>
            new Livro
            {
                Id = Convert.ToInt32(reader["Id"]),
                Titulo = reader["Titulo"].ToString(),
                Tema = reader["Tema"].ToString(),
                Autor = reader["Autor"].ToString(),
                Volume = Convert.ToInt32(reader["Volume"]),
                DataPublicacao = Convert.ToDateTime(reader["DataPublicacao"]),
                Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"])
            };
    }
}
