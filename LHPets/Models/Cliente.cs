using System.ComponentModel.DataAnnotations;

namespace LHPets.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(
            @"^\d{11}$",
            ErrorMessage = "O CPF deve conter exatamente 11 números."
        )]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido.")]
        public string Email { get; set; } = string.Empty;
    }
}