using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Funcionalidades.Interfaces
{
    public interface IService<T>
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        T Buscar(int id);
        void Excluir(T entidade);
        IEnumerable<T> BuscarTodos();
    }
}
