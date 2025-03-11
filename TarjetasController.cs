using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("tarjetas")]
    public class TarjetasController: ControllerBase
    {
        [HttpPost]

        /*  Puede aparecer error en ProcesarTarjeta porque el task espera retornar algo y si lo tenemos vacio,por eso sucede*/
        public async Task<ActionResult> 
            ProcesarTarjeta([FromBody] string tarjeta)
        {
            var valorAleatorio = RandomGen.NextDouble(); //Obtenemos el valor aleatorio
            var aprobada = valorAleatorio > 0.1; // 0.1 es un valor que nos dice que masomenos el 10% serán rechazados

            await Task.Delay(1000); //Simulamos que el procesamiento tarda 1 segundo

            Debug.WriteLine("Tarjeta " + tarjeta + "procesada"); //Mostramos el estatus en consola

            return Ok(new { Tarjeta = tarjeta, Aprobada = aprobada }); //Devolvemos la respuesta de la tarjeta
        }
    }
}
