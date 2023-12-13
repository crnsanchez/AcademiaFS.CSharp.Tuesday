using AcademiaFS.CSharp.Tuesday._Features.ConteoPersonasGrupo;
using AcademiaFS.CSharp.Tuesday._Features.ConteoPersonasGrupo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.CSharp.Tuesday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteoPersonasGrupoController(ConteoPersonasGrupoService service) : ControllerBase
    {
        private ConteoPersonasGrupoService Service => service;

        [HttpPost("ConteoPersonasGrupo")]
        public IActionResult ConteoPersonasGrupo(ConteoPersonas conteoPersonas)
        {

            try
            {
                var resultado = Service.ObtenerListadoPersonas(conteoPersonas);

                return Ok(resultado);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return Problem(ex.Message.ToString());
            }
        }
    }
}
