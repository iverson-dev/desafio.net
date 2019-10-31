using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class Calculator
    {

        private async Task<decimal> GetTaxaJuros()
        {
            string url = "http://localhost:5000/taxaJuros";
            using (HttpClient client = new HttpClient())
            {         
                string ret = await client.GetStringAsync(url);
                decimal juros;
                return decimal.TryParse(ret.Replace(".", ","), out juros)? juros: 0.00M;
            }
        }
        public async Task<decimal> CalculaJuros(decimal valorInicial = 0.00M, int meses = 0)
        {

            decimal juros = 1 + await GetTaxaJuros();

            return Convert.ToDecimal(Math.Truncate(100 * (Convert.ToDouble(valorInicial) * Math.Pow(Convert.ToDouble(juros), Convert.ToDouble(meses)))) / 100);
        }
    }
}
