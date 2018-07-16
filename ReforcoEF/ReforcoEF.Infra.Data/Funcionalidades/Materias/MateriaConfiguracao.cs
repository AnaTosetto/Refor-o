using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Materias;
using ReforcoEF.Dominio.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Infra.Data.Funcionalidades.Materias
{
    public class MateriaConfiguracao : EntityTypeConfiguration<Materia>
    {
        public MateriaConfiguracao()
        {
            ToTable("TBMateria");

            HasKey(m => m.Id);
            Property(m => m.Id).HasColumnName("IdMateria");

            Property(m => m.Nome).IsRequired();

            HasMany(m => m.Alunos);
        }
    }
}
