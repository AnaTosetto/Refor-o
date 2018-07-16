using ProvaTDD.Dominio.Funcionalidades.Avaliacoes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Infra.Data.Funcionalidades.Avaliacoes
{
    public class AvaliacaoConfiguracao : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoConfiguracao()
        {
            ToTable("TBAvaliacao");

            HasKey(avaliacao => avaliacao.Id);

            Property(avaliacao => avaliacao.Data).IsRequired();
            Property(avaliacao => avaliacao.Assunto).IsRequired();
        }
    }
}
