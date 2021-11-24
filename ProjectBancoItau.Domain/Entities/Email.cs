using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Entities
{
    public class Email
    {
        public string de { get; set; }
        public string para { get; set; }
        public string assunto { get; set; }
        public string mensagem { get; set; }
    }
}
