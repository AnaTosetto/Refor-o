using Prova2.Dominio.Features.Livros.Exceptions;
using System;

namespace Prova2.Dominio.Features.Livros
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Tema { get; set; }
        public string Autor { get; set; }
        public int Volume { get; set; }
        public DateTime DataPublicacao { get; set; }
        public virtual bool Disponibilidade { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Titulo))
                throw new TituloNuloOuVazioException();
            if (string.IsNullOrEmpty(Tema))
                throw new TemaNuloOuVazioException();
            if (string.IsNullOrEmpty(Autor))
                throw new AutorNuloOuVazioException();
            if (Titulo.Length < 4)
                throw new TituloComCaracteresMinimoException();
            if (Tema.Length < 4)
                throw new TemaComCaracteresMinimoException();
            if (Autor.Length < 4)
                throw new AutorComCaracteresMinimoException();
            if (Volume == 0)
                throw new VolumeIgualZeroException();
            if (DataPublicacao.Day > DateTime.Now.Day)
                throw new DataDePublicacaoInvalidaException();
        }
    }
}
