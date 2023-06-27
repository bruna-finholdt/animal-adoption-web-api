using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdoçãoDeAnimais2023.Domain.DTO
{
    public class AnimalCreateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório cadastrar o nome do animal")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É obrigatório cadastrar a idade do animal")]
        public int? idade { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório cadastrar a espécie do animal")]
        public string Especie { get; set; }

        public DateTime? DataDeNascimento { get; set; }

        [Range(1, 5, ErrorMessage = "O Nível de fofura precisa ser um número entre 1 e 5")]
        public int? NivelDeFofura { get; set; }

        [Range(1, 5, ErrorMessage = "O Nível de carinho precisa ser um número entre 1 e 5")]
        public int? NivelDeCarinho { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O email precisa ser válido")]
        public string EmailParaContato { get; set; }
    }
}
