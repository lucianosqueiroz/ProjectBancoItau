using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBancoItau.MVC.ViewModels
{
    public class ClienteContaViewModel
    {



        [DisplayName("Id Conta")]
        public int IdConta { get; set; }

        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        //[MinLength(11, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        //usado para atualiaçao de cpfs

        [MaxLength(90, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Cliente")]
        public string Nome { get; set; }
        [DisplayName("Id Cliente")]
        public int idCliente { get; set; }

       
        [DisplayName("Conta")]
        public int NConta { get; set; }
        [DisplayName("Dígito Conta")]
        public int CDigito { get; set; }
        [DisplayName("Agência")]
        public int NAgencia { get; set; }
        [DisplayName("Dígito Agência")]
        public int ADigito { get; set; }
        [DisplayName("Senha")]
        public string Senha { get; set; }
        

        [DataType(DataType.Currency)]
        //[Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        [DisplayName("Saldo")]
        public decimal Saldo { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}