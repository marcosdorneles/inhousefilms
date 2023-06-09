using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmesInHouse.Context;
using filmesInHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace filmesInHouse.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/filmes")]
    public class FilmesController : Controller
    {

        private readonly FilmesContext _filmeContext;

        public FilmesController(FilmesContext filmesContext) {
            _filmeContext = filmesContext;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            var filmes = await _filmeContext.Filmes.ToListAsync().ConfigureAwait(true);
            return Ok(filmes);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task <IActionResult> Get(int id)
        {
            //pesquisar pelo id e retornar se for verdadeiro
            Filme? filme = await _filmeContext.Filmes
                                                    .FirstOrDefaultAsync(x => x.Id == id)
                                                    .ConfigureAwait(true);

            //erro 404 caso não exista
            if(filme is null)
            {
                return NotFound();
            }
            // caso encontre, status 200
            return Ok(filme);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody]Filme filme)
        {
            _filmeContext.Filmes.Add(filme);
            await _filmeContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <IActionResult> Put (int id, [FromBody]Filme filme)
        {
            bool existeFilme = await _filmeContext.Filmes.AnyAsync(x => x.Id == id).ConfigureAwait(true);

            if(!existeFilme)
            {
                return NotFound();
            }

            _filmeContext.Entry(filme).State = EntityState.Modified;
            await _filmeContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            var filme = await _filmeContext.Filmes.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(true);

            if (filme is null)
            {
                return NotFound();
            }

            _filmeContext.Filmes.Remove(filme);
            await _filmeContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

