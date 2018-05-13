using DonaLaura.Domain.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Features.Vendas
{
    public class VendaService
    {
        IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public Venda Adiciona(Venda venda)
        {
            return venda;
        }

        public Venda Atualiza(Venda venda)
        {
            return venda;
        }

        public void Exclui(Venda venda)
        {

        }

        public Venda Obtem(int id)
        {
            return null;
        }

        public IEnumerable<Venda> ObtemTudo()
        {
            return null;
        }
    }
}
