using SalaDeReuniao.Dominio.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Infra.Data.Funcionalidades.Funcionarios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        string _sqlInserir = @"INSERT INTO Funcionario
                                (Nome, Cargo, Ramal)
                              VALUES
                                (@Nome, @Cargo, @Ramal);";

        string _sqlEditar = @"UPDATE Funcionario
                                SET Nome = @Nome, Cargo = @Cargo, Ramal = @Ramal
                                WHERE Id = @Id";

        string _sqlExcluir = @"DELETE FROM Funcionario 
                                WHERE Id = @Id";

        string _sqlObter = @"SELECT * FROM Funcionario
                            WHERE Id = @Id";

        string _sqlObterTudo = @"SELECT * FROM Funcionario";

        public Funcionario Adicionar(Funcionario funcionario)
        {
            funcionario.Id = Db.Insert(_sqlInserir, Take(funcionario));
            return funcionario;
        }

        public Funcionario Atualizar(Funcionario funcionario)
        {
            if(funcionario.Id > 0)
            {
                Db.Update(_sqlEditar, Take(funcionario));
                return funcionario;
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public void Excluir(Funcionario funcionario)
        {
            if(funcionario.Id > 0)
            {
                Db.Delete(_sqlExcluir, Take(funcionario));
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public Funcionario Obter(int id)
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

        public IEnumerable<Funcionario> ObterTudo()
        {
            return Db.GetAll<Funcionario>(_sqlObterTudo, Make);
        }

        private object[] Take(Funcionario funcionario)
        {
            return new object[]
            {
                "@Id", funcionario.Id,
                "@Nome", funcionario.Nome,
                "@Cargo", funcionario.Cargo,
                "@Ramal", funcionario.Ramal
            };
        }

        private static Func<IDataReader, Funcionario> Make = reader =>
            new Funcionario
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                Cargo = reader["Cargo"].ToString(),
                Ramal = reader["Ramal"].ToString()
            };
    }
}
