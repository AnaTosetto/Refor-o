using DonaLaura.Domain.Features.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Aplicacao.Features.Vendas
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
            venda.Validate();
            return _vendaRepository.Adicionar(venda);
        }

        public Venda Atualiza(Venda venda)
        {
            venda.Validate();
            return _vendaRepository.Atualizar(venda);
        }

        public void Exclui(Venda venda)
        {
            _vendaRepository.Excluir(venda);
        }

        public Venda Obtem(int id)
        {
            return _vendaRepository.Obter(id);
        }

        public IEnumerable<Venda> ObtemTudo()
        {
            return _vendaRepository.ObterTudo();
        }
    }
}
