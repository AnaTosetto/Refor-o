using SalaDeReuniao.Dominio.Funcionalidades.Funcionarios;
using SalaDeReuniao.Funcionalidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Funcionalidades.Funcionarios
{
    public class FuncionarioService : IService<Funcionario>
    {
        IFuncionarioRepositorio _funcionarioRepositorio;

        public FuncionarioService(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public Funcionario Adicionar(Funcionario funcionario)
        {
            funcionario.Validar();

            return _funcionarioRepositorio.Adicionar(funcionario);
        }

        public Funcionario Atualizar(Funcionario funcionario)
        {
            funcionario.Validar();

            return _funcionarioRepositorio.Atualizar(funcionario);
        }

        public void Excluir(Funcionario funcionario)
        {
            _funcionarioRepositorio.Excluir(funcionario);
        }

        public IEnumerable<Funcionario> ObterTudo()
        {
            return _funcionarioRepositorio.ObterTudo();
        }

        public Funcionario Obter(int id)
        {
            return _funcionarioRepositorio.Obter(id);
        }
    }
}
