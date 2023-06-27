using AdoçãoDeAnimais2023.Domain.DTO;
using AdoçãoDeAnimais2023.Domain.Entity;
using AdoçãoDeAnimais2023.Services.Base;
using AdoçãoDeAnimais2023.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Net.Mail;

namespace AdoçãoDeAnimais2023.Services
{
    public class AnimaisService
    {
        private static List<Animal>? listaDeAnimais = new List<Animal>();
        private static int proximoId = 1;

        //public AnimaisService()
        //{
        //    if (listaDeAnimais == null)
        //    {
        //        listaDeAnimais = new List<Animal>();
        //        listaDeAnimais.Add(new Animal()
        //        {
        //            Id = proximoId++,
        //            Nome = "D'artagnan",
        //            Idade = 5,
        //            Especie = "Gato",
        //            DataDeNascimento = new DateTime(2018, 01, 15),
        //            NivelDeFofura = 5,
        //            NivelDeCarinho = 3,
        //            EmailParaContato = "bruna@gmail.com",
        //        });
        //    }
        //}

        public ServiceResponse<Animal> CadastrarNovo(AnimalCreateRequest model)
        {

            List<string> Especies = new List<string>()
            {
                "cachorro", "gato", "coelho", "capivara"
            };

            if (!Especies.Contains(model.Especie.ToLower()))
            {
                return new ServiceResponse<Animal>("Somente é possível cadastrar animais que sejam das espécies Cachorro, Gato, Coelho ou Capivara");
            }

            var novoAnimal = new Animal()
            {
                Id = proximoId++,
                Nome = model.Nome,
                Idade = model.idade.Value,
                Especie = model.Especie.ToLower(),
                DataDeNascimento = model.DataDeNascimento.Value,
                NivelDeFofura = model.NivelDeFofura.Value,
                NivelDeCarinho = model.NivelDeCarinho.Value,
                EmailParaContato = model.EmailParaContato,
            };

            listaDeAnimais?.Add(novoAnimal);
            return new ServiceResponse<Animal>(novoAnimal);
        }

        public List<Animal>? ListarTodos()
        {
            return listaDeAnimais;
        }

        public ServiceResponse<Animal> PesquisarPorId(int id)
        {
            var resultado = listaDeAnimais?.Where(x => x.Id == id).FirstOrDefault(); //?
            if (resultado == null)
            {
                return new ServiceResponse<Animal>("Animal não encontrado!");
            }
            else
            {
                return new ServiceResponse<Animal>(resultado);
            }
        }

        public ServiceResponse<Animal> PesquisarPorNome(string nome)
        {
            var resultado = listaDeAnimais?.Where(x => x.Nome == nome).FirstOrDefault(); //?
            if (resultado == null)
            {
                return new ServiceResponse<Animal>("Animal não encontrado!");
            }
            else
            {
                return new ServiceResponse<Animal>(resultado);
            }
        }

        public ServiceResponse<Animal> Editar(int id, AnimalUpdateRequest model)
        {
            var resultado = listaDeAnimais?.Where(x => x.Id == id).FirstOrDefault();
            if (resultado == null)
            {
                return new ServiceResponse<Animal>("Animal não encontrado!");
            }
            //sendo encontrado => atualizando...
            resultado.NivelDeFofura = model.NivelDeFofura;
            resultado.NivelDeCarinho = model.NivelDeCarinho;
            resultado.EmailParaContato = model.EmailParaContato;

            return new ServiceResponse<Animal>(resultado);
        }
        public ServiceResponse<bool> Deletar(int id)
        {
            var resultado = listaDeAnimais?.Where(x => x.Id == id).FirstOrDefault();
            if (resultado == null)
            {
                return new ServiceResponse<bool>("Animal não encontrado!");
            }
            //sendo encontrado => deletando...
            listaDeAnimais?.Remove(resultado);

            return new ServiceResponse<bool>(true);
        }

    }
}
