using Pizzaria.Dominio.Funcionalidades.Entregas;
using Pizzaria.Funcionalidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Funcionalidades.Entregas
{
    public class EntregaServico : IService<Entrega>
    {
        IEntregaRepositorio _entregaRepositorio;

        public EntregaServico(IEntregaRepositorio entregaRepositorio)
        {
            _entregaRepositorio = entregaRepositorio;
        }

        public Entrega Adicionar(Entrega entrega)
        {
            entrega.Validar();

            return _entregaRepositorio.Adicionar(entrega);
        }

        public Entrega Atualizar(Entrega entrega)
        {
            entrega.Validar();
            return _entregaRepositorio.Atualizar(entrega);
        }

        public Entrega Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entrega> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Entrega entrega)
        {
            throw new NotImplementedException();
        }
    }
}
