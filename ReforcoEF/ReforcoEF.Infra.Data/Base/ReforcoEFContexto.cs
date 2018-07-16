using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Enderecos;
using ReforcoEF.Dominio.Funcionalidades.Materias;
using ReforcoEF.Dominio.Funcionalidades.Resultados;
using ReforcoEF.Infra.Data.Funcionalidades.Alunos;
using ReforcoEF.Infra.Data.Funcionalidades.Materias;
using ReforcoEF.Infra.Data.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Infra.Data.Base
{
    public class ReforcoEFContexto : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Materia> Materias { get; set; }

        public ReforcoEFContexto() : base ("ReforcoEF")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Properties()
            //       .Where(p => p.Name == p.ReflectedType.Name + "Id")
            //       .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AlunoConfiguracao());
            modelBuilder.Configurations.Add(new ResultadoConfiguracao());
            modelBuilder.Configurations.Add(new MateriaConfiguracao());
            base.OnModelCreating(modelBuilder);
        }
    }
}
