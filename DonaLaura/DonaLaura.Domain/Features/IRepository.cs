using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features
{
    public interface IRepository<T>
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        void Excluir(T entidade);
        T Obter(long Id);
        IEnumerable<T> ObterTudo();
    }
}
