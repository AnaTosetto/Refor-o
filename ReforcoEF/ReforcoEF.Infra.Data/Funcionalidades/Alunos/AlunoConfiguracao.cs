using ReforcoEF.Dominio.Funcionalidades.Alunos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Infra.Data.Funcionalidades.Alunos
{
    public class AlunoConfiguracao : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfiguracao()
        {
            ToTable("TBAluno");
            HasKey(a => a.Id);
            Property(r => r.Id).HasColumnName("IdAluno");

            Property(a => a.Nome).IsRequired();
            Property(a => a.Endereco.Numero);
            Property(a => a.Endereco.Rua);
            HasMany(a => a.Resultados);
            HasMany(a => a.Materias).WithMany(a => a.Alunos)
                .Map(cs =>
                {
                    cs.MapLeftKey("AlunoId");
                    cs.MapRightKey("MateriaId");
                    cs.ToTable("TBAlunoMateria");
                });
        }
    }
}
