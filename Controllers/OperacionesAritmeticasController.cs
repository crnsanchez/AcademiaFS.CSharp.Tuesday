using AcademiaFS.CSharp.Tuesday._Features.OperacionesAritmeticas;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.CSharp.Tuesday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesAritmeticasController(OperacionesAritmeticasService service) : ControllerBase
    {
        private OperacionesAritmeticasService Service => service;

        [HttpGet("operaciones")]
        public IActionResult RealizarTodasLasOperaciones(int Numero1, int Numero2)
        {

            try
            {
                var resultado = new
                {
                    Suma = Service.Sumar(Numero1, Numero2),
                    Resta = Service.Restar(Numero1, Numero2),
                    Multiplicacion = Service.Multiplicar(Numero1, Numero2),
                    Division = Service.Dividir(Numero1, Numero2)
                };
                return Ok(resultado);
            }
            catch (DivideByZeroException ex)
            {
                return Problem(ex.Message.ToString());
            }
        }

        [HttpGet("sumar")]
        public IActionResult Sumar(int Numero1, int Numero2)
        {
            var resultadoSuma = Service.Sumar(Numero1, Numero2);
            return Ok(resultadoSuma);
        }

        [HttpGet("restar")]
        public IActionResult Restar(int Numero1, int Numero2)
        {
            var resultadoResta = Service.Restar(Numero1, Numero2);
            return Ok(resultadoResta);
        }

        [HttpGet("multiplicar")]
        public IActionResult Multiplicar(int Numero1, int Numero2)
        {
            var resultadoMultiplicacion = Service.Multiplicar(Numero1, Numero2);
            return Ok(resultadoMultiplicacion);
        }

        [HttpGet("dividir")]
        public IActionResult Dividir(int Numero1, int Numero2)
        {
            try
            {
                var resultadoDivision = Service.Dividir(Numero1, Numero2);
                return Ok(resultadoDivision);
            }
            catch (DivideByZeroException ex)
            {

                return Problem(ex.Message.ToString());
            }
        }
    }
}
