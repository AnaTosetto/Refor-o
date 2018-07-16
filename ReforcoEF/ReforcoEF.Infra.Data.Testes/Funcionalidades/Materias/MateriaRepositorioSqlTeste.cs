using FluentAssertions;
using NUnit.Framework;
using ReforcoEF.Comum.Testes.Base;
using ReforcoEF.Comum.Testes.Funcionalidades;
using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Enderecos;
using ReforcoEF.Dominio.Funcionalidades.Materias;
using ReforcoEF.Infra.Data.Base;
using ReforcoEF.Infra.Data.Funcionalidades.Alunos;
using ReforcoEF.Infra.Data.Funcionalidades.Materias;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Infra.Data.Testes.Funcionalidades.Alunos
{
    [TestFixture]
    public class MateriaRepositorioSqlTeste
    {
        ReforcoEFContexto _reforcoEFContexto;
        IMateriaRepositorio _materiaRepositorio;
        Materia _materia;

        [SetUp]
        public void IniciarCenario()
        {
            _reforcoEFContexto = new ReforcoEFContexto();
            Database.SetInitializer(new BaseSqlTeste());
            _reforcoEFContexto.Database.Initialize(true);
            _materiaRepositorio = new MateriaRepositorioSQL(_reforcoEFContexto);
            _materia = new Materia();
        }

        [Test]
        public void Materia_InfraData_Adicionar_Sucesso()
        {
            _materia = ObjectMother.ObterMateriaValido();

            _materia = _materiaRepositorio.Adicionar(_materia);

            _materia.Should().NotBeNull();
            _materia.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Materia_InfraData_Atualizar_Sucesso()
        {
            int id = 1;
            _materia = _materiaRepositorio.Buscar(id);
            _materia.Nome = "matematica";

            _materiaRepositorio.Editar(_materia);

            Materia alunoBuscado = _materiaRepositorio.Buscar(_materia.Id);

            alunoBuscado.Id.Should().Be(_materia.Id);
            alunoBuscado.Nome.Should().Be(_materia.Nome);
        }

        [Test]
        public void Materia_InfraData_BuscarPorId_Sucesso()
        {
            _materia = null;
            int id = 1;

            _materia = _materiaRepositorio.Buscar(id);

            _materia.Should().NotBeNull();
            _materia.Id.Should().Be(id);
            _materia.Nome.Should().NotBeEmpty();
            _materia.Alunos.First().Id.Should().Be(id);
        }

        [Test]
        public void Materia_InfraData_Excluir_Sucesso()
        {
            _materia = null;
            int id = 1;
            _materia = _materiaRepositorio.Buscar(id);

            _materiaRepositorio.Excluir(_materia);

            Materia materiaBuscado = _materiaRepositorio.Buscar(id);

            materiaBuscado.Should().BeNull();
        }

        [Test]
        public void Materia_InfraData_BuscarTodos_Sucesso()
        {
            IEnumerable<Materia> listaMateria;

            listaMateria = _materiaRepositorio.BuscarTodos();

            listaMateria.Should().NotBeNull();
            listaMateria.Count().Should().Be(1);
        }
    }
}
