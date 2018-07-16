using ProvaTDD.Dominio.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Infra.Data.Funcionalidades.Enderecos
{
    public class EnderecoConfiguracao : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguracao()
        {
            ToTable("TBEndereco");

            HasKey(endereco => endereco.Id);
            Property(endereco => endereco.Numero).IsRequired();
            Property(endereco => endereco.Rua).IsRequired();
        }
    }
}
