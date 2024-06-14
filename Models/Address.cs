using System.ComponentModel.DataAnnotations;
using UserManageAPI.Models;

namespace LoremIpsumLogistica.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "CEP inválido")]
        public string CEP { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "UF deve ter 2 caracteres")]
        public string UF { get; set; }

        public int UserId { get; set; }

    }
}