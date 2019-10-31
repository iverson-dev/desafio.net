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

        /// <summary>
        /// Retorna o montante final de uma aplicação a juros compostos a partir dos parâmetros passados.
        /// </summary>
        /// <remarks>Função com parâmetros. Calcula-se os juros compostos a partir do valor inicial pela quantidade de meses informado. A taxa de juros é obtida automaticamente.</remarks>
        /// <param name="valorInicial">Valor inicial a ser investido.</param>
        /// <param name="meses">Quantidade de meses aplicados</param>
        /// <response code="200">Total calculado no período.</response>        
        /// <response code="500">Oops! Houve algum problema ao chamar o serviço!</response>
        [HttpGet("calculaJuros")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Retorna o repositório no github onde o projeto foi salvo.
        /// </summary>
        /// <remarks></remarks>
        /// <response code="200">Link para o repositório.</response>        
        /// <response code="500">Oops! Houve algum problema ao chamar o serviço!</response>

        [HttpGet("showmethecode")]
        public string Get()
        {
            return "https://github.com/iverson-dev/desafio.net";
        }
    }
}
