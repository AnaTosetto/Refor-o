using ReforcoEF.Dominio.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Dominio.Funcionalidades.Resultados
{
    public interface IResultadoRepositorio
    {
        Resultado Adicionar(Resultado resultado);
        Resultado Editar(Resultado resultado);
        Resultado Buscar(int id);
        IList<Resultado> BuscarTodos();
        void Excluir(Resultado resultado);
    }
}
