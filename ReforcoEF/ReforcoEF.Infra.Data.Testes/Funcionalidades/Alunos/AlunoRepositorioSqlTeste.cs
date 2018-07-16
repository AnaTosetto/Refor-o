using FluentAssertions;
using NUnit.Framework;
using ReforcoEF.Comum.Testes.Base;
using ReforcoEF.Comum.Testes.Funcionalidades;
using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Enderecos;
using ReforcoEF.Infra.Data.Base;
using ReforcoEF.Infra.Data.Funcionalidades.Alunos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Infra.Data.Testes.Funcionalidades.Alunos
{
    [TestFixture]
    public class AlunoRepositorioSqlTeste
    {
        ReforcoEFContexto _reforcoEFContexto;
        IAlunoRepositorio _alunoRepositorio;
        Aluno _aluno;
        Endereco _endereco;

        [SetUp]
        public void IniciarCenario()
        {
            _reforcoEFContexto = new ReforcoEFContexto();
            Database.SetInitializer(new BaseSqlTeste());
            _reforcoEFContexto.Database.Initialize(true);
            _alunoRepositorio = new AlunoRepositorioSQL(_reforcoEFContexto);
            _aluno = new Aluno();
            _endereco = ObjectMother.ObterEnderecoValido();
        }

        [Test]
        public void Aluno_InfraData_Adicionar_Sucesso()
        {
            _aluno = ObjectMother.ObterAlunoValido(_endereco);

            _aluno = _alunoRepositorio.Adicionar(_aluno);

            _aluno.Should().NotBeNull();
            _aluno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Aluno_InfraData_Atualizar_Sucesso()
        {
            int id = 1;
            _aluno = _alunoRepositorio.Buscar(id);
            _aluno.Nome = "Ana";

            _alunoRepositorio.Editar(_aluno);

            Aluno alunoBuscado = _alunoRepositorio.Buscar(_aluno.Id);

            alunoBuscado.Id.Should().Be(_aluno.Id);
            alunoBuscado.Nome.Should().Be(_aluno.Nome);
            alunoBuscado.Endereco.Rua.Should().Be(_aluno.Endereco.Rua);
            alunoBuscado.Endereco.Numero.Should().Be(_aluno.Endereco.Numero);
        }

        [Test]
        public void Aluno_InfraData_BuscarPorId_Sucesso()
        {
            _aluno = null;
            int id = 1;

            _aluno = _alunoRepositorio.Buscar(id);

            _aluno.Should().NotBeNull();
            _aluno.Id.Should().Be(id);
            _aluno.Nome.Should().NotBeEmpty();
            _aluno.Resultados.First().Id.Should().Be(id);
            _aluno.Materias.First().Id.Should().Be(id);
        }

        [Test]
        public void Aluno_InfraData_Excluir_Sucesso()
        {
            _aluno = null;
            int id = 1;
            _aluno = _alunoRepositorio.Buscar(id);

            _alunoRepositorio.Excluir(_aluno);

            Aluno alunoBuscado = _alunoRepositorio.Buscar(id);

            alunoBuscado.Should().BeNull();
        }

        [Test]
        public void Aluno_InfraData_BuscarTodos_Sucesso()
        {
            IEnumerable<Aluno> listaAluno;

            listaAluno = _alunoRepositorio.BuscarTodos();

            listaAluno.Should().NotBeNull();
            listaAluno.Count().Should().Be(1);
        }
    }
}
