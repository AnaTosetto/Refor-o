using Prova2.Dominio.Features.Emprestimos;
using Prova2.Dominio.Features.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Features.Emprestimos
{
    public class EmprestimoService : IService<Emprestimo>
    {
        IEmprestimoRepositorio _emprestimoRepositorio;
        public EmprestimoService(IEmprestimoRepositorio emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
        }

        public Emprestimo Adiciona(Emprestimo emprestimo)
        {
            emprestimo.Validar();

            return _emprestimoRepositorio.Adicionar(emprestimo);
        }

        public Emprestimo Atualiza(Emprestimo emprestimo)
        {
            emprestimo.Validar();

            return _emprestimoRepositorio.Atualizar(emprestimo);
        }

        public void Exclui(Emprestimo emprestimo)
        {
            _emprestimoRepositorio.Excluir(emprestimo);
        }

        public Emprestimo Obtem(int id)
        {
            return _emprestimoRepositorio.Obter(id);
        }

        public IEnumerable<Emprestimo> ObtemTudo()
        {
            return _emprestimoRepositorio.ObterTudo();
        }
    }
}
