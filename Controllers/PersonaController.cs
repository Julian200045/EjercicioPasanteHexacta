using EjercicioPasanteHexacta.Models;
using EjercicioPasanteHexacta.Services;
using EjercicioPasanteHexacta.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EjercicioPasanteHexacta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        IPersonaService personaService;

        private readonly ILogger<PersonaController> _logger;

        public PersonaController(ILogger<PersonaController> logger, IPersonaService service) {

            _logger = logger;
            personaService = service;

        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? nombre = "", [FromQuery] string? apellido = "")
        {

            IEnumerable<PersonaView> personasViews = personaService.Get(nombre, apellido).Select(persona => (PersonaView)persona);

            return Ok(personasViews);

        }

        [HttpPost]
        public IActionResult Post([FromBody] )
        {


            personaService.Save(persona);
            return Ok();
        }
    }
}
