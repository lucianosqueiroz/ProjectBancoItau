using ProjectBancoItau.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBancoItau.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int idCliente { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cpf")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        //[MinLength(11, ErrorMessage = "Mínimo {0} caracteres")]
        public string Cpf { get; set; }

        //usado para atualiaçao de cpfs

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(90, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
       public virtual IEnumerable<Conta> Contas { get; set; }
    }
}