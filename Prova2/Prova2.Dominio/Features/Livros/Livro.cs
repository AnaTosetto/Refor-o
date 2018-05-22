using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool Disponibilidade { get; set; }

        public void Validar()
        {

        }
    }
}
