using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Dominio.Funcionalidades.Alunos;
using ProvaTDD.Dominio.Funcionalidades.Enderecos;
using ProvaTDD.Dominio.Funcionalidades.Resultados;
using ProvaTDD.Infra.Data.Base;
using ProvaTDD.Infra.Data.Funcionalidades.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Infra.Data.Testes.Funcionalidades.Alunos
{
    [TestFixture]
    public class AlunoRepositorioTeste
    {
        ProvaContexto _provaContexto;
        IAlunoRepositorio _alunoRepositorio;
        Aluno _aluno;
        Endereco _endereco;

        [SetUp]
        public void IniciarCenario()
        {
            _provaContexto = new ProvaContexto();
            _alunoRepositorio = new AlunoRepositorio(_provaContexto);
            _aluno = new Aluno();
            _endereco = new Endereco();
            _endereco.Numero = 23;
            _endereco.Rua = "rua";
        }

        [Test]
        public void Aluno_InfraData_Adicionar_Sucesso()
        {
            _aluno.Idade = 20;
            _aluno.Nome = "Ana";

            _aluno = _alunoRepositorio.Adicionar(_aluno);

            _aluno.Id.Should().BeGreaterThan(0);
        }
    }
}
