using NUnit.Framework;
using Prova2.Comum.Testes.Features.Livros;
using Prova2.Dominio.Features.Livros;
using Prova2.Features.Livros;
using Prova2.Infra.Data.Features.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Integracao.Testes.Features.Livros
{
    public class LivroIntegracaoSistema
    {
        LivroRepositorio _livroRepositorio = new LivroRepositorio();

        LivroService _livroService;

        [SetUp]
        public void TestSetup()
        {
            _livroService = new LivroService(_livroRepositorio);
        }

        [Test]
        public void LivroIntegracaoSistema_Adicionar_DeveSerValido()
        {
            //Cenário
            Livro livro = ObjectMother.ObterLivroValido();
            livro.Id = 0;

            //Ação
            Livro livroResultado = _livroService.Adiciona(livro);


        }
    }
}
