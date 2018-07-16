using ProvaTDD.Dominio.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Infra.Data.Funcionalidades.Resultados
{
    public class ResultadoConfiguracao : EntityTypeConfiguration<Resultado>
    {
        public ResultadoConfiguracao()
        {
            ToTable("TBResultado");

            HasKey(resultado => resultado.Id);

            HasRequired(resultado => resultado.Aluno);
            HasRequired(resultado => resultado.Avaliacao);

            Property(resultado => resultado.Nota).IsRequired();
        }
    }
}
