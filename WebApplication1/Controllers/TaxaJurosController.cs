using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {        
        private readonly ILogger<TaxaJurosController> _logger;

        public TaxaJurosController(ILogger<TaxaJurosController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retorna a taxa de juros a ser utilizada
        /// </summary>
        /// <remarks>Função sem parâmetros. Inicialmente a taxa de juros é fixa para todas as requisições.</remarks>
        /// <response code="200">Taxa de juros atual</response>        
        /// <response code="500">Oops! Houve algum problema ao chamar o serviço</response>
        [HttpGet]
        [ProducesResponseType(typeof(decimal), 200)]
        [ProducesResponseType(500)]
        public decimal Get()
        {            
            return new TaxaJuros().Taxa;
        }
    }
}
