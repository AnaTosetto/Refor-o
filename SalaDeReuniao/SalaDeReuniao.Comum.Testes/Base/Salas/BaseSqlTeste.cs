using SalaDeReuniao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Comum.Testes.Base.Salas
{
    public static class BaseSqlTeste
    {
        private const string RECREATE_SALA_TABLE = "TRUNCATE TABLE Agendamento; DELETE FROM Sala DBCC CHECKIDENT('Sala', RESEED, 0)";

        private const string INSERT_SALA = "INSERT INTO Sala(Nome, Lugar) VALUES ('Sala de reunião', 4)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_SALA_TABLE);
            Db.Update(INSERT_SALA);
        }
    }
}
