
using ProvaTDD.Dominio.Funcionalidades.Alunos;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace ProvaTDD.Infra.Data.Funcionalidades.Alunos
{
    public class AlunoConfiguracao : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfiguracao()
        {
            ToTable("TBAluno");

            HasKey(aluno => aluno.Id);
            HasMany(aluno => aluno.Resultados);
            Property(a => a.Endereco.Numero);
            Property(a => a.Endereco.Rua);

            Property(aluno => aluno.Nome).IsRequired();
            Property(aluno => aluno.Idade).IsRequired();
            Property(aluno => aluno.Media).IsOptional();
        }
    }
}
