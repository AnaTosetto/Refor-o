using FluentAssertions;
using NUnit.Framework;
using ReforcoEF.Comum.Testes.Base;
using ReforcoEF.Comum.Testes.Funcionalidades;
using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Enderecos;
using ReforcoEF.Dominio.Funcionalidades.Resultados;
using ReforcoEF.Infra.Data.Base;
using ReforcoEF.Infra.Data.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Infra.Data.Testes.Funcionalidades.Resultados
{
    [TestFixture]
    public class ResultadoRepositorioSqlTeste
    {
        ReforcoEFContexto _reforcoEFContexto;
        IResultadoRepositorio _resultadoRepositorio;
        Aluno _aluno;
        Resultado _resultado;
        Endereco _endereco;


        [SetUp]
        public void IniciarCenario()
        {
            _reforcoEFContexto = new ReforcoEFContexto();
            Database.SetInitializer(new BaseSqlTeste());
            _reforcoEFContexto.Database.Initialize(true);
            _resultadoRepositorio = new ResultadoRepositorioSQL(_reforcoEFContexto);
            _endereco = ObjectMother.ObterEnderecoValido();
            _aluno = ObjectMother.ObterAlunoValido(_endereco);
            _resultado = new Resultado();
        }

        [Test]
        public void Resultado_InfraData_Adicionar_Sucesso()
        {
            _resultado = ObjectMother.ObterResultadoValido(_aluno);

            _resultado = _resultadoRepositorio.Adicionar(_resultado);

            _resultado.Should().NotBeNull();
            _resultado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Resultado_InfraData_Atualizar_Sucesso()
        {
            int id = 1;
            _resultado = _resultadoRepositorio.Buscar(id);
            _resultado.Nota = 10;

            _resultadoRepositorio.Editar(_resultado);

            Resultado resultadoBuscado = _resultadoRepositorio.Buscar(_resultado.Id);

            resultadoBuscado.Id.Should().Be(_resultado.Id);
            resultadoBuscado.Nota.Should().Be(_resultado.Nota);
            resultadoBuscado.Aluno.Nome.Should().Be(_resultado.Aluno.Nome);
        }

        [Test]
        public void Resultado_InfraData_BuscarPorId_Sucesso()
        {
            _resultado = null;
            int id = 1;

            _resultado = _resultadoRepositorio.Buscar(id);

            _resultado.Should().NotBeNull();
            _resultado.Id.Should().Be(id);
            _resultado.Aluno.Should().NotBeNull();
        }

        [Test]
        public void Resultado_InfraData_Excluir_Sucesso()
        {
            _resultado = null;
            int id = 1;
            _resultado = _resultadoRepositorio.Buscar(id);

            _resultadoRepositorio.Excluir(_resultado);

            Resultado resultadoBuscado = _resultadoRepositorio.Buscar(id);

            resultadoBuscado.Should().BeNull();
        }

        [Test]
        public void Resultado_InfraData_BuscarTodos_Sucesso()
        {
            IEnumerable<Resultado> listaResultado;

            listaResultado = _resultadoRepositorio.BuscarTodos();

            listaResultado.Should().NotBeNull();
            listaResultado.Count().Should().Be(1);
        }
    }
}
