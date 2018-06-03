using SalaDeReuniao.Dominio.Excecoes;
using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Infra.Data.Funcionalidades.Salas
{
    public class SalaRepositorio : ISalaRepositorio
    {
        string _sqlInserir = @"INSERT INTO Sala
                                (Nome, Lugar, Disponibilidade)
                              VALUES
                                (@Nome, @Lugar, @Disponibilidade);";

        string _sqlEditar = @"UPDATE Sala
                                SET Nome = @Nome, Lugar = @Lugar, Disponibilidade = @Disponibilidade
                                WHERE Id = @Id";

        string _sqlExcluir = @"DELETE FROM Sala 
                                WHERE Id = @Id";

        string _sqlObter = @"SELECT * FROM Sala
                            WHERE Id = @Id";

        string _sqlObterTudo = @"SELECT * FROM Sala";

        public Sala Adicionar(Sala sala)
        {
            sala.Id = Db.Insert(_sqlInserir, Take(sala));
            return sala;
        }

        public Sala Atualizar(Sala sala)
        {
            if (sala.Id > 0)
            {
                Db.Update(_sqlEditar, Take(sala));
                return sala;
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public void Excluir(Sala sala)
        {
            if (sala.Id > 0)
            {
                Db.Delete(_sqlExcluir, Take(sala));
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public Sala Obter(int id)
        {
            if (id > 0)
            {
                return Db.Get(_sqlObter, Make, new object[] { "@Id", id });
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public IEnumerable<Sala> ObterTudo()
        {
            return Db.GetAll<Sala>(_sqlObterTudo, Make);
        }

        private object[] Take(Sala sala)
        {
            return new object[]
            {
                "@Id", sala.Id,
                "@Nome", sala.Nome,
                "@Lugar", sala.Lugar,
                "@Disponibilidade", sala.Disponibilidade
            };
        }

        private static Func<IDataReader, Sala> Make = reader =>
            new Sala
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                Lugar = Convert.ToInt32(reader["Lugar"]),
                Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"])
            };
    }
}
