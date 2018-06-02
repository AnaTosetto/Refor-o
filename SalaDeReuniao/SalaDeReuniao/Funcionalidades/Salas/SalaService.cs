using SalaDeReuniao.Dominio.Funcionalidades.Salas;
using SalaDeReuniao.Funcionalidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Funcionalidades.Salas
{
    public class SalaService : IService<Sala>
    {
        ISalaRepositorio _salaRepositorio;

        public SalaService(ISalaRepositorio salaRepositorio)
        {
            _salaRepositorio = salaRepositorio;
        }

        public Sala Adicionar(Sala sala)
        {
            sala.Validar();

            return _salaRepositorio.Adicionar(sala);
        }

        public Sala Atualizar(Sala sala)
        {
            sala.Validar();

            return _salaRepositorio.Atualizar(sala);
        }

        public void Excluir(Sala sala)
        {
            _salaRepositorio.Excluir(sala);
        }

        public Sala Obter(int id)
        {
            return _salaRepositorio.Obter(id);
        }

        public IEnumerable<Sala> ObterTudo()
        {
            return _salaRepositorio.ObterTudo();
        }
    }
}
