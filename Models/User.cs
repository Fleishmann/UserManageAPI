using LoremIpsumLogistica.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManageAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [EnumDataType(typeof(Sexo))]
        public Sexo Sexo { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }

    public enum Sexo
    {
        Masculino,
        Feminino
    }
}