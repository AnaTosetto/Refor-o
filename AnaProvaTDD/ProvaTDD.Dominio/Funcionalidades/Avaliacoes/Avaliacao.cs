using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Funcionalidades.Avaliacoes
{
    public class Avaliacao : Entidade
    {
        public string Assunto { get; set; }
        public DateTime Data { get; set; }
        public virtual List<Resultado> Resultados { get; set; }
    }
}
