using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBancoItau.MVC.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Login { get; set; }
        public bool Gerente { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MaxLength(10, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(6, ErrorMessage = "Mínimo {0} caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}