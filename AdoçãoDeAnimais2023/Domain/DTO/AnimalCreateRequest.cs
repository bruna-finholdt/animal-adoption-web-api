using System;
using System.ComponentModel.DataAnnotations;

namespace AdoçãoDeAnimais2023.Domain.DTO
{
    public class AnimalCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required]
        public int? idade { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Especie { get; set; }

        public DateTime? DataDeNascimento { get; set; }

        [Range(1, 5)]
        public int? NivelDeFofura { get; set; }

        [Range(1, 5)]
        public int? NivelDeCarinho { get; set; }

        [Required]
        [EmailAddress]
        public string EmailParaContato { get; set; }
    }
}
