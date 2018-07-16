using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Resultados;
using ReforcoEF.Infra.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Infra.Data.Funcionalidades.Resultados
{
    public class ResultadoRepositorioSQL : IResultadoRepositorio
    {
        ReforcoEFContexto _reforcoEFContexto;

        public ResultadoRepositorioSQL(ReforcoEFContexto reforcoEFContexto)
        {
            _reforcoEFContexto = reforcoEFContexto;
        }

        public Resultado Adicionar(Resultado resultado)
        {
            resultado = _reforcoEFContexto.Resultados.Add(resultado);
            _reforcoEFContexto.SaveChanges();

            return resultado;
        }

        public Resultado Buscar(int id)
        {
            Resultado resultado = _reforcoEFContexto.Resultados.Find(id);
            return resultado;
        }

        public IList<Resultado> BuscarTodos()
        {
            return _reforcoEFContexto.Resultados.ToList();
        }

        public Resultado Editar(Resultado resultado)
        {
            _reforcoEFContexto.SaveChanges();
            return resultado;
        }

        public void Excluir(Resultado resultado)
        {
            _reforcoEFContexto.Resultados.Remove(resultado);
            _reforcoEFContexto.SaveChanges();
        }
    }
}
