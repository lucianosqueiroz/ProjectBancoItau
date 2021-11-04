using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Entities
{
    public class LogTransacao
    {
        public int IdLogTransacao { get; set; }
        public int IdTrans { get; set; }
        public int IdConta { get; set; }
        public int IdCliente { get; set; }
        public decimal ValorTrans { get; set; }
        public DateTime DataTrans{ get; set; }

    }
}
