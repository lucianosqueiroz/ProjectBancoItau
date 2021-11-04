using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Entities
{
    public class Conta
    {
        public int IdConta { get; set; }
        public int NConta { get; set; }
        public int CDigito { get; set; }
        public int NAgencia { get; set; }
        public int ADigito { get; set; }
        public string Senha { get; set; }
        
        public decimal Saldo { get; set; }
        public int idCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
