using System.ComponentModel.DataAnnotations;

namespace AppBancoLM.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public int? IdCli { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string nomeCli { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O email não é valido.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email valido...")]
        public string Email { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatório")]
        [DataType(DataType.DateTime)]
        public DateTime DataNasc { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "O sexo é obrigatório.")]
        [StringLength(1, ErrorMessage = "Deve conter 1 caracter.")]
        public string Sexo { get; set; }
    }
}
