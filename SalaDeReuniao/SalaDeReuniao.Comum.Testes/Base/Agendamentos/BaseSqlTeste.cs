using SalaDeReuniao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Comum.Testes.Base.Agendamentos
{
    public static class BaseSqlTeste
    {
        private const string INSERT_AGENDAMENTO = "INSERT INTO Agendamento(HoraInicial, HoraFinal, FuncionarioId, SalaId) VALUES (GETDATE(), GETDATE(), 1, 1)";

        public static void SeedDatabase()
        {
            Funcionarios.BaseSqlTeste.SeedDatabase();
            Salas.BaseSqlTeste.SeedDatabase();
            Db.Update(INSERT_AGENDAMENTO);
        }
    }
}
