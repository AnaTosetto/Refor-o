using Prova2.Dominio.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Comum.Testes.Features.Livros
{
    public static partial class ObjectMother
    {
        public static Livro ObterLivroValido()
        {
            return new Livro
            {
                Titulo = "titulo",
                Tema = "tema",
                Autor = "autor",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-2),
                Disponibilidade = true
            };
        }

        public static Livro ObterLivroInvalido_TituloNuloOuVazio()
        {
            return new Livro
            {
                Titulo = "",
                Tema = "tema",
                Autor = "autor",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-2),
                Disponibilidade = true
            };
        }

        public static Livro ObterLivroInvalido_TemaNuloOuVazio()
        {
            return new Livro
            {
                Titulo = "titulo",
                Tema = "",
                Autor = "autor",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-2),
                Disponibilidade = true
            };
        }

        public static Livro ObterLivroInvalido_AutorNuloOuVazio()
        {
            return new Livro
            {
                Titulo = "titulo",
                Tema = "tema",
                Autor = "",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-2),
                Disponibilidade = true
            };
        }

        public static Livro ObterLivroInvalido_TituloComCaracteresMinimos()
        {
            return new Livro
            {
                Titulo = "abc",
                Tema = "tema",
                Autor = "autor",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-2),
                Disponibilidade = true
            };
        }

        public static Livro ObterLivroInvalido_TemaComCaracteresMinimos()
        {
            return new Livro
            {
                Titulo = "titulo",
                Tema = "abc",
                Autor = "autor",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-2),
                Disponibilidade = true
            };
        }

        public static Livro ObterLivroInvalido_AutorComCaracteresMinimos()
        {
            return new Livro
            {
                Titulo = "titulo",
                Tema = "tema",
                Autor = "abc",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(-2),
                Disponibilidade = true
            };
        }

        public static Livro ObterLivroInvalido_VolumeIgualZero()
        {
            return new Livro
            {
                Titulo = "titulo",
                Tema = "tema",
                Autor = "autor",
                Volume = 0,
                DataPublicacao = DateTime.Now.AddDays(-2),
                Disponibilidade = true
            };
        }

        public static Livro ObterLivroInvalido_DataPublicacaoInvalida()
        {
            return new Livro
            {
                Titulo = "titulo",
                Tema = "tema",
                Autor = "autor",
                Volume = 1,
                DataPublicacao = DateTime.Now.AddDays(2),
                Disponibilidade = true
            };
        }

    }
}
