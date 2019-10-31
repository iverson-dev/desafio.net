using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("calculaJuros")]
        public async Task<string> calculaJuros([FromQuery] decimal valorInicial, [FromQuery] int meses)
        {
            Calculator calculadora = new Calculator();
            decimal result;
            try
            {
                result = await calculadora.CalculaJuros(valorInicial, meses);
            }
            catch
            {
                return "Não foi possível obter a taxa de juros.";
            }
            return result.ToString("F");
        }

        [HttpGet("showmethecode")]
        public string Get()
        {
            return "https://github.com/iverson-dev/desafio.net";
        }
    }
}
