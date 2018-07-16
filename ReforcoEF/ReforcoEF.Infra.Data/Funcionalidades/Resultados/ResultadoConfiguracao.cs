using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Infra.Data.Funcionalidades.Resultados
{
    public class ResultadoConfiguracao : EntityTypeConfiguration<Resultado>
    {
        public ResultadoConfiguracao()
        {
            ToTable("TBResultado");

            HasKey(r => r.Id);
            Property(r => r.Id).HasColumnName("IdResultado");

            Property(r => r.Nota).IsRequired();

            //one to many aluno -Resultado
           HasRequired(r => r.Aluno).WithMany().HasForeignKey(r => r.AlunoId);
        }
    }
}
