using AcademiaFS.CSharp.Tuesday._Features.ContadorCaracteres;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.CSharp.Tuesday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContadorCaracteresController(ContadorCaracteresService service) : ControllerBase()
    {
        private ContadorCaracteresService Service => service;

        [HttpGet("contadorCaracteres")]
        public IActionResult ContadorCaracteres(string input)
        {
            var resultado = new
            {
                characterCount = Service.CountCharacters(input),
                wordCount = Service.CountWords(input),
                reversedString = Service.ReverseString(input)
            };


            return Ok(resultado);
        }
    }
}
