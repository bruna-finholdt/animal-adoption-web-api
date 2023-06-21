using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoçãoDeAnimais2023.Domain.Entity
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public string Especie { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public int? NivelDeFofura { get; set; }
        public int? NivelDeCarinho { get; set; }
        public string EmailParaContato { get; set; }

    }
}
