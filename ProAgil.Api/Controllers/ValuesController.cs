using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.Api.Model;

namespace ProAgil.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
            return new Evento[] { 
                new Evento() {
                    EventoId = 1,
                    Tema = "Projeto Angular com .NET Core",
                    Local = "Mateus Leme",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEnvio = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                },
                new Evento() {
                    EventoId = 2,
                    Tema = "Curso de Progrmação",
                    Local = "Contagem",
                    Lote = "2º Lote",
                    QtdPessoas = 380,
                    DataEnvio = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                }
            };
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            return new Evento[] { 
                new Evento() {
                    EventoId = 1,
                    Tema = "Projeto Angular com .NET Core",
                    Local = "Mateus Leme",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEnvio = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                },
                new Evento() {
                    EventoId = 2,
                    Tema = "Curso de Progrmação",
                    Local = "Contagem",
                    Lote = "2º Lote",
                    QtdPessoas = 380,
                    DataEnvio = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                }
            }.FirstOrDefault(x => x.EventoId == id);
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        /*[HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }*/
    }
}
