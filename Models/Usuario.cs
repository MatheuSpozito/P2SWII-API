using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P2SWII_API.Models
{

    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Nome { get; set; }
        
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Senha { get; set; }

        public bool Status { get; set; }

    }
}