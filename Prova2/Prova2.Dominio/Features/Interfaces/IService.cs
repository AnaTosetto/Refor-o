using System.Collections.Generic;

namespace Prova2.Dominio.Features.Interfaces
{
    public interface IService<T>
    {
        T Adiciona(T entidade);
        T Atualiza(T entidade);
        T Obtem(int id);
        void Exclui(T entidade);
        IEnumerable<T> ObtemTudo();
    }
}
