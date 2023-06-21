﻿using System.ComponentModel.DataAnnotations;

namespace AdoçãoDeAnimais2023.Domain.DTO
{
    public class AnimalUpdateRequest
    {
        [Range(1, 5)]
        public int? NivelDeFofura { get; set; }
        [Range(1, 5)]
        public int? NivelDeCarinho { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Animal não encontrado!")]
        public string EmailParaContato { get; set; }
    }
}
