using ReforcoEF.Comum.Testes.Funcionalidades;
using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Enderecos;
using ReforcoEF.Dominio.Funcionalidades.Materias;
using ReforcoEF.Dominio.Funcionalidades.Resultados;
using ReforcoEF.Infra.Data.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Comum.Testes.Base
{
    public class BaseSqlTeste : DropCreateDatabaseAlways<ReforcoEFContexto>
    {
        protected override void Seed(ReforcoEFContexto reforcoEFContexto)
        {
            //Aluno aluno = reforcoEFContexto.Alunos.Add(ObjectMother.ObterAlunoValido(ObjectMother.ObterEnderecoValido()));
            Aluno aluno = ObjectMother.ObterAlunoValido(ObjectMother.ObterEnderecoValido());
            Resultado resultado = reforcoEFContexto.Resultados.Add(ObjectMother.ObterResultadoValido(aluno));
            Materia materia = ObjectMother.ObterMateriaValido();

            aluno.Resultados.Add(resultado);
            aluno.Materias.Add(materia);

            materia.Alunos.Add(aluno);

            reforcoEFContexto.Alunos.Add(aluno);
            reforcoEFContexto.Materias.Add(materia);

            reforcoEFContexto.SaveChanges();
            base.Seed(reforcoEFContexto);
        }
    }
}
