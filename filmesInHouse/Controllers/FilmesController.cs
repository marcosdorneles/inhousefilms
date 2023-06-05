using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmesInHouse.Models;
using Microsoft.AspNetCore.Mvc;


namespace filmesInHouse.Controllers
{
    [Route("api/v{version:apiVersion}/filmes")]
    public class FilmesController : Controller
    {

        /// <summary>
        /// Lista Mocada de Filmes
        /// </summary>
        /// <returns>Retorna uma lista mocada de filmes</returns>
        /// <response code=200></response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MockFilmes.Filmes);
        }

        /// <summary>
        /// Requisição de um item de uma lista de filmes mocada
        /// </summary>
        /// <param name="id">Id do Filme</param>
        /// <returns>Retorna objeto do filme</returns>
        /// <response code ="404">Id não encontrado</response>
        /// <response code="200"> Sucesso no retorno do filme selecionado pelo Id</response>>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get(int id)
        {
            //pesquisar pelo id e retornar se for verdadeiro
            Filme filme = MockFilmes.Filmes.FirstOrDefault(x => x.Id == id);

            //erro 404 caso não exista
            if(filme is null)
            {
                return NotFound();
            }
            // caso encontre, status 200
            return Ok(filme);
        }

        /// <summary>
        /// Criação de novo filme na lista mocada
        /// </summary>
        /// <param name="filme">Objeto do Filme</param>
        /// <returns>Novo filme</returns>
        /// <response code="201">Objeto criado com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody]Filme filme)
        {
            MockFilmes.Filmes.Add(filme);
            return CreatedAtAction(nameof(Get), new { id = filme.Id }, filme);
        }

        /// <summary>
        /// Atualiza filme da lista
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filme"></param>
        /// <returns>filme atualizado</returns>
        /// <response code="404">filme não encontrado</response>
        /// <response code="204">Atualização concluída com sucesso</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put (int id, [FromBody]Filme filme)
        {
            Filme filmeUpdate = MockFilmes.Filmes.FirstOrDefault(x => x.Id == id);

            if(filme is null)
            {
                return NotFound();
            }

            //Em resumo, esse trecho de código verifica se o filme existe na lista
            //e, se existir, substitui o filme existente pelo novo filme fornecido na solicitação.
            var index = MockFilmes.Filmes.IndexOf(filmeUpdate);
            if(index != -1)
            {
                MockFilmes.Filmes[index] = filme;
                
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta filme da lista
        /// </summary>
        /// <param name="id">id do filme</param>
        /// <returns>filme deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Filme filme = MockFilmes.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme is null)
            {
                return NotFound();
            }

            MockFilmes.Filmes.Remove(filme);

            return NoContent();
        }
    }
}

