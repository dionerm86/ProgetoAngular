using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Dominio;
using ProAgil.Repositorio;

namespace ProAgil.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly IProagilRepositorio _repos;

        public PalestranteController(IProagilRepositorio repos)
        {
            _repos = repos;
        }


        [HttpGet("{PalestranteId}")]
        public async Task<IActionResult> Get(int PalestranteId) 
        {
            try
            {
                var results = await _repos.GetPalestranteAsync(PalestranteId, true);

                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
        }

        [HttpGet("getByPalestrante/{nome}")]
        public async Task<IActionResult> Get(string nome) 
        {
            try
            {
                var results = await _repos.GetPalestrantesAsyncByName(nome, true);

                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Palestrante model) 
        {
            try
            {
                _repos.Add(model);
                
                if(await _repos.SaveChangesAsync())
                {
                    return Created($"/api/palestrante/{model.Id}", model);
                }
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }

            return BadRequest("Erro na Requisição!!!");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Palestrante model, int palestranteId) 
        {
            try
            {
                var palestrante = await _repos.GetPalestranteAsync(palestranteId, false);
                
                if(palestrante == null)
                {
                    return NotFound("Palestrante não encontrado!");
                }

                _repos.Update(model);

                if(await _repos.SaveChangesAsync())
                {
                    return Created($"/api/palestrante/{model.Id}", model);
                }
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }

            return BadRequest("Erro na Requisição!!!");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int palestranteId, Palestrante model) 
        {
            try
            {
                var palestrante = await _repos.GetPalestranteAsync(palestranteId, false);
                
                if(palestrante == null)
                {
                    return NotFound("Palestrante não encontrado!");
                }

                _repos.Delete(model);

                if(await _repos.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }

            return BadRequest("Erro na Requisição!!!");
        }


    }
}