using AcademiaFS.CSharp.Tuesday._Features.EstudiantesPromedio;
using AcademiaFS.CSharp.Tuesday._Features.EstudiantesPromedio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.CSharp.Tuesday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController(EstudiantePromedioService service) : ControllerBase
    {

        private EstudiantePromedioService Service => service;

        [HttpGet("obtenerEstudiante")]
        public IActionResult ObtenerEstudiante(int Id)
        {

            try
            {

                var resultado = Service.ObtenerPromedioEstudiante(Id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message.ToString());
            }
        }


        [HttpPost("agregarEstudiante")]
        public IActionResult AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                Service.AgregarEstudiante(estudiante);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message.ToString());
            }
        }

        [HttpPost("agregarEstudiantes")]
        public IActionResult AgregarEstudiante(List<Estudiante> estudiantes)
        {
            try
            {

                foreach (Estudiante estudiante in estudiantes)
                {
                    Service.AgregarEstudiante(estudiante);
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message.ToString());
            }
        }


        [HttpGet("obtenesEstudiantes")]
        public IActionResult ObtenesEstudiantes()
        {
            try
            {
                var response = Service.ObtenerEstudiantes();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message.ToString());
            }
        }

        [HttpGet("obtenesEdadPromedioEstudiantes")]
        public IActionResult ObtenesEdadPromedioEstudiantes()
        {
            try
            {
                var response = Service.ObtenesEdadPromedioEstudiantes();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message.ToString());
            }
        }

        [HttpGet("calificacionEsAprobatoria")]
        public IActionResult CalificacionEsAprobatoria(int calificacion)
        {
            try
            {
                var response = Service.CalificacionEsAprobatoria(calificacion);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message.ToString());
            }
        }
        [HttpGet("buscarEstudiantePorNombre")]
        public IActionResult BuscarEstudiantePorNombre(string nombreEstudiante)
        {
            try
            {
                var response = Service.BuscarEstudiantePorNombre(nombreEstudiante);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message.ToString());
            }
        }
    }
}
