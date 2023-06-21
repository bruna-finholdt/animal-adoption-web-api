using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdoçãoDeAnimais2023.Domain.DTO;
using AdoçãoDeAnimais2023.Domain.Entity;
using AdoçãoDeAnimais2023.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoçãoDeAnimais2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        //usando o AnimaisService via injeção de dependência:
        private readonly AnimaisService animalService;
        public AnimaisController(AnimaisService animalService)
        {
            this.animalService = animalService;
        }

        [HttpGet]
        public IEnumerable<Animal>? Get()
        {
            return animalService?.ListarTodos();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = animalService.PesquisarPorId(id);
            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }

        [HttpGet("nome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var retorno = animalService.PesquisarPorNome(nome);
            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AnimalCreateRequest postModel)
        {
            //validação modelo de entrada
            if (ModelState.IsValid)//modelState é o objeto que guarda o estado de validação do modelo de entrada, ou seja
                                   //a validação dos parametros do metodo
            {
                var retorno = animalService.CadastrarNovo(postModel);
                if (!retorno.Sucesso)
                {
                    return BadRequest(retorno.Mensagem);
                }
                else
                {
                    return Ok(retorno);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnimalUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = animalService.Editar(id, putModel);
                if (!retorno.Sucesso)
                {
                    return BadRequest(retorno.Mensagem);
                }
                else
                {
                    return Ok(retorno.ObjetoRetorno);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var retorno = animalService.Deletar(id);
            if (!retorno.Sucesso)
            {
                return BadRequest(retorno.Mensagem);
            }
            else
            {
                return Ok();
            }
        }

    }
}
