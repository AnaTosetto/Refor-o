using Prova2.Dominio.Features.Interfaces;
using Prova2.Dominio.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Features.Livros
{
    public class LivroService : IService<Livro>
    {
        ILivroRepositorio _livroRepositorio;

        public LivroService(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public Livro Adiciona(Livro livro)
        {
            livro.Validar();

            return _livroRepositorio.Adicionar(livro);
        }

        public Livro Atualiza(Livro livro)
        {
            livro.Validar();

            return _livroRepositorio.Atualizar(livro);
        }

        public void Exclui(Livro entidade)
        {
            throw new NotImplementedException();
        }

        public Livro Obtem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Livro> ObtemTudo()
        {
            throw new NotImplementedException();
        }
    }
}
