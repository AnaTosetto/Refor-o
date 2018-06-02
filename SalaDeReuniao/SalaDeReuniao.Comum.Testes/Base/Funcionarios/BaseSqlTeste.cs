using SalaDeReuniao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Comum.Testes.Base.Funcionarios
{
    public static class BaseSqlTeste
    {
        private const string RECREATE_FUNCIONARIO_TABLE = "TRUNCATE TABLE Agendamento; DELETE FROM Funcionario DBCC CHECKIDENT('DBSalaDeReuniao.dbo.Funcionario', RESEED, 0)";

        private const string INSERT_FUNCIONARIO = "INSERT INTO Funcionario(Nome, Cargo, Ramal) VALUES ('Liana', 'Webinar', 'Comercial')";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_FUNCIONARIO_TABLE);
            Db.Update(INSERT_FUNCIONARIO);
        }
    }
}
