using EjercicioPasante.Models;
using EjercicioPasanteHexacta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioPasanteHexacta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        IPersonaService personaService;

        private readonly ILogger<PersonaController> _logger;

        //private static List<Persona> ListPersona = new List<Persona>(); //borrar

        public PersonaController(ILogger<PersonaController> logger,IPersonaService service) {
            
            _logger = logger;
            personaService = service;

        }

        [HttpGet] 
        public IActionResult Get([FromQuery] string? nombre="", [FromQuery] string? apellido = "")
        {
            return Ok(personaService.Get(nombre, apellido));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            personaService.Save(persona);
            return Ok();
        }
    }
}
