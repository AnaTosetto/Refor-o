using Prova2.Dominio.Exceptions;
using Prova2.Dominio.Features.Emprestimos;
using Prova2.Dominio.Features.Livros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Infra.Data.Features.Emprestimos
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        string _sqlInserir = @"INSERT INTO Emprestimo
                                (NomeCliente, LivroId, DataDevolucao)
                              VALUES
                                (@NomeCliente, @LivroId, @DataDevolucao);";

        string _sqlEditar = @"UPDATE Emprestimo
                                SET NomeCliente = @NomeCliente, LivroId = @LivroId, DataDevolucao = @DataDevolucao
                             WHERE Id = @Id";

        string _sqlExcluir = @"DELETE FROM Emprestimo
                                WHERE Id = @Id";

        string _sqlObter = @"SELECT * FROM Emprestimo
                                WHERE Id = @Id";

        string _sqlObterTudo = @"SELECT * FROM Emprestimo";


        public Emprestimo Adicionar(Emprestimo emprestimo)
        {
            emprestimo.Validar();
            emprestimo.Id = Db.Insert(_sqlInserir, Take(emprestimo));
            return emprestimo;
        }

        public Emprestimo Atualizar(Emprestimo emprestimo)
        {
            emprestimo.Validar();
            if(emprestimo.Id > 0)
            {
                Db.Update(_sqlEditar, Take(emprestimo));
                return emprestimo;
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public void Excluir(Emprestimo emprestimo)
        {
            if(emprestimo.Id > 0)
            {
                Db.Delete(_sqlExcluir, Take(emprestimo));
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public Emprestimo Obter(int id)
        {
            if(id > 0)
            {
                return Db.Get(_sqlObter, Make, new object[] { "@Id", id });
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public IEnumerable<Emprestimo> ObterTudo()
        {
            return Db.GetAll<Emprestimo>(_sqlObterTudo, Make);
        }

        private object[] Take(Emprestimo emprestimo)
        {
            return new object[]
            {
                "@Id", emprestimo.Id,
                "@NomeCliente", emprestimo.NomeCliente,
                "@LivroId", emprestimo.Livro.Id,
                "@DataDevolucao", emprestimo.DataDevolucao
            };
        }

        private static Func<IDataReader, Emprestimo> Make = reader =>
        new Emprestimo
        {
            Id = Convert.ToInt32(reader["Id"]),
            NomeCliente = reader["NomeCliente"].ToString(),
            DataDevolucao = Convert.ToDateTime(reader["DataDevolucao"]),
            Livro = new Livro
            {
                Id = Convert.ToInt32(reader["LivroId"]),
            }
        };
    }
}
