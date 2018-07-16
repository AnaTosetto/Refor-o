using ProvaTDD.Dominio.Funcionalidades.Alunos;
using ProvaTDD.Dominio.Funcionalidades.Avaliacoes;
using ProvaTDD.Dominio.Funcionalidades.Enderecos;
using ProvaTDD.Dominio.Funcionalidades.Resultados;
using ProvaTDD.Infra.Data.Funcionalidades.Alunos;
using ProvaTDD.Infra.Data.Funcionalidades.Avaliacoes;
using ProvaTDD.Infra.Data.Funcionalidades.Enderecos;
using ProvaTDD.Infra.Data.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Infra.Data.Base
{
    public class ProvaContexto : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public ProvaContexto() : base("ProvaTDD")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AlunoConfiguracao());
            modelBuilder.Configurations.Add(new AvaliacaoConfiguracao());
            modelBuilder.Configurations.Add(new ResultadoConfiguracao());
            modelBuilder.Configurations.Add(new EnderecoConfiguracao());
            base.OnModelCreating(modelBuilder);
        }
    }
}
