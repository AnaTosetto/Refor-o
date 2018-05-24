using Prova2.Dominio.Features.Emprestimos.Exceptions;
using Prova2.Dominio.Features.Livros;
using System;

namespace Prova2.Dominio.Features.Emprestimos
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public Livro  Livro { get; set; }
        public DateTime DataDevolucao { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(NomeCliente))
                throw new NomeNuloOuVazioException();
            if (Livro.Disponibilidade == false)
                throw new LivroIndisponivelException();
        }
    }
}
