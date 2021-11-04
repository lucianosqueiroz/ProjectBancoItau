using ProjectBancoItau.Domain.Services.RegrasNegócio.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Entities
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<Conta> Contas { get; set; }

        public bool IsValid ()
        {
            return CpfServices.ValidaCPF(Cpf);
        }
    }
}
