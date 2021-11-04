using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBancoItau.MVC.ViewModels
{
    public class ContaViewModel
    {
        [Key]
        [DisplayName("Conta")]
        public int IdConta { get; set; }
        [DisplayName("Conta")]
        public int NConta { get; set; }
        [DisplayName("Dígito")]
        public int CDigito { get; set; }
        [DisplayName("Agência")]
        public int NAgencia { get; set; }
        [DisplayName("Dígito Agência")]
        public int ADigito { get; set; }
        [DisplayName("Senha")]
        public string Senha { get; set; }
        

        [DataType(DataType.Currency)]
        [Range(typeof(decimal),"0", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal Saldo { get; set; }

        [DisplayName("Cliente")]
        public string idCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}