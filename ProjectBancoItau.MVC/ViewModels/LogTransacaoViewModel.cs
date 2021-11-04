using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBancoItau.MVC.ViewModels
{
    public class LogTransacaoViewModel
    {
        [Key]
        public int IdLogTransacao { get; set; }
        public int IdTrans { get; set; }
        public int IdConta { get; set; }
        public int IdCliente { get; set; }
        public decimal ValorTrans { get; set; }
        public DateTime DataTrans { get; set; }
    }
}