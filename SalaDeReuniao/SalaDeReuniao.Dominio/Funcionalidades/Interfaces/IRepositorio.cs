using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Interfaces
{
    public interface IRepositorio<T>
    {
        T Adicionar(T entidade);
        T Atualizar(T entidade);
        T Obter(int id);
        void Excluir(T entidade);
        IEnumerable<T> ObterTudo();
    }
}
