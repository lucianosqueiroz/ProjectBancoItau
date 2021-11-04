using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBancoItau.MVC.ViewModels
{
    public class TransacaoViewModel
    {
        [Key]
        public int IdTransacao { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}