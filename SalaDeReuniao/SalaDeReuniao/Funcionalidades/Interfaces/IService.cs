using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Funcionalidades.Interfaces
{
    public interface IService<T>
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        T Obter(int id);
        void Excluir(T entidade);
        IEnumerable<T> ObterTudo();
    }
}
