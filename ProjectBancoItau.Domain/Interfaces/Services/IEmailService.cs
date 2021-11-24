using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        void Enviar(Email email);
    }
}
