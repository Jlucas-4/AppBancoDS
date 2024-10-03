using System.ComponentModel.DataAnnotations;

namespace AppBancoLM.Models
{
    public class Usuario
    {
        [Display(Name = "Código")]
        public int? IdUsua { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string nomeUsua { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "O campo cargo é obrigatório")]
        public string Cargo { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatório")]
        [DataType(DataType.DateTime)]

        public DateTime DataNasc { get; set; }

    }
}
