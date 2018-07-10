using ProvaTDD.Dominio.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Funcionalidades.Avaliacoes
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public string Assunto { get; set; }
        public DateTime Data { get; set; }
        public List<Resultado> Resultados { get; set; }
    }
}
