using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Funcionalidades.Interfaces
{
    public interface IRepositorio<T>
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        T Buscar(int id);
        void Excluir(T entidade);
        IEnumerable<T> BuscarTodos();
    }
}
