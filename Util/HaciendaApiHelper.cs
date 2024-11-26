using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BikerStriker.Util
{
    public static class HaciendaApiHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> ObtenerNombrePorCedulaAsync(string cedula)
        {
            try
            {
                string url = $"https://api.hacienda.go.cr/fe/ae?identificacion={cedula}";

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Error: Verifique la cédula ingresada.");
                    return null;
                }

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JObject.Parse(responseBody);

                string nombre = jsonResponse["nombre"]?.ToString();

                return nombre ?? "Nombre no encontrado";
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Error al realizar la solicitud: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error inesperado: {e.Message}");
                return null;
            }
        }
    }
}
