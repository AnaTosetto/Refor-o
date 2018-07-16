using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Base
{
    public abstract class Entidade
    {
        public int Id { get; set; }
    }
}
