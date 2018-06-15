using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcUsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O Campo CPF é Obrigatorio")]
        public string Cpf { get; set; }
        public string Telefone { get; set; }

    }
}