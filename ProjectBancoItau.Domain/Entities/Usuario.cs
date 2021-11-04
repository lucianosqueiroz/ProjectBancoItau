using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public bool Gerente { get; set; }
        public string Senha { get; set; }

        public bool UsuarioGerente(Usuario usuario)
        {
            return usuario.Gerente == true;
        }
    }
}
