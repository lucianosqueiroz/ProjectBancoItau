using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectBancoItau.API.Controllers
{
    public class EmailController : ApiController
    {
        private readonly IEmailService _emailSevice;

        public EmailController(IEmailService emailService)
        {
            _emailSevice = emailService;
        }

        public IHttpActionResult Post(Email email)
        {
            _emailSevice.Enviar(email);
            return Ok();
            
        }
    }
}
