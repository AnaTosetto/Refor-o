using SalaDeReuniao.Dominio.Funcionalidades.Salas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Salas
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Lugar { get; set; }
        public virtual bool Disponibilidade { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new NomeNuloOuVazioException();
            if (Lugar == 0)
                throw new LugarIgualAZeroException();
        }
    }
}
