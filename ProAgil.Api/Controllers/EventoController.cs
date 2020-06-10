using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Dominio;
using ProAgil.Repositorio;  
using System.Threading.Tasks;

namespace ProAgil.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProagilRepositorio _repos;

        public EventoController(IProagilRepositorio repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repos.GetAllEventosAsync(true); 

                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco!");
            }
        }


        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var results = await _repos.GetAllEventoAsyncById(EventoId, true);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
        }



        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var results = await _repos.GetAllEventosAsyncByTema(tema, true);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }
        }



        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                _repos.Add(model);

                if(await _repos.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }

            return BadRequest("Não encontrado");
        }


        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, Evento model)
        {
            try
            {
                var evento = await _repos.GetAllEventoAsyncById(EventoId, false);

                if (evento == null)
                {
                    return NotFound("O evento não foi encontrado");
                }

                _repos.Update(model);

                if (await _repos.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }

            return BadRequest("Não encontrado");
        }

        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete(int EventoId)
        {
            try
            {
                var evento = await _repos.GetAllEventoAsyncById(EventoId, false);

                if (evento == null)
                {
                    return NotFound("O evento não foi encontrado");
                }

                _repos.Delete(evento);

                
                if (await _repos.SaveChangesAsync())
                {
                    return Ok();
                }                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco");
            }

            return BadRequest();
        }
    }
}
