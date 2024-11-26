using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BikerStriker.Util
{
    public class HaciendaApiHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> ObtenerNombrePorCedulaAsync(string cedula)
        {
            try
            {
                string url = $"https://api.hacienda.go.cr/fe/ae?identificacion={cedula}";

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JObject.Parse(responseBody);

                string nombre = jsonResponse["nombre"]?.ToString();

                return nombre ?? "Nombre no encontrado";
            }
            catch (HttpRequestException e)
            {
                return $"Error al realizar la solicitud: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Error inesperado: {e.Message}";
            }
        }
    }
}
