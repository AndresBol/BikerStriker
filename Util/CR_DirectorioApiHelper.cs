using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Util
{
    public class CR_DirectorioApiHelper
    {
        public CR_DirectorioApiHelper() { LlenarListasAsync(); }

        private readonly HttpClient client = new HttpClient();
        private readonly string UrlProvincia = "https://raw.githubusercontent.com/AndresBol/CR_Directorio/main/provincias.json";
        private readonly string UrlCanton = "https://raw.githubusercontent.com/AndresBol/CR_Directorio/main/cantones.json";
        private readonly string UrlDistrito = "https://raw.githubusercontent.com/AndresBol/CR_Directorio/main/distritos.json";

        public List<Provincia> Provincias { get; private set; }
        public List<Canton> Cantones { get; private set; }
        public List<Distrito> Distritos { get; private set; }

        public async Task LlenarListasAsync()
        {
            try
            {
                // Obtener Provincias
                Provincias = await ObtenerProvincias();
                if (Provincias == null || Provincias.Count == 0)
                {
                    throw new Exception("No se pudieron cargar las provincias.");
                }

                // Obtener Cantones utilizando las provincias cargadas
                Cantones = await ObtenerCantones(Provincias);
                if (Cantones == null || Cantones.Count == 0)
                {
                    throw new Exception("No se pudieron cargar los cantones.");
                }

                // Obtener Distritos utilizando los cantones cargados
                Distritos = await ObtenerDistritos(Cantones);
                if (Distritos == null || Distritos.Count == 0)
                {
                    throw new Exception("No se pudieron cargar los distritos.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al llenar las listas: {e.Message}");
            }
        }

        private async Task<List<Provincia>> ObtenerProvincias()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(UrlProvincia);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JArray jsonResponse = JArray.Parse(responseBody);

                List<Provincia> provincias = jsonResponse
                    .Select(item => new Provincia(Convert.ToInt32(item["IdProvincia"]), item["Descripcion"]?.ToString()))
                    .ToList();

                return provincias;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al obtener provincias: {e.Message}");
                return null;
            }
        }

        private async Task<List<Canton>> ObtenerCantones(List<Provincia> provincias)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(UrlCanton);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JArray jsonResponse = JArray.Parse(responseBody);

                List<Canton> cantones = jsonResponse
                    .Where(item => provincias.Any(p => p.Id == Convert.ToInt32(item["IdProvincia"])))
                    .Select(item =>
                    {
                        var provincia = provincias.First(p => p.Id == Convert.ToInt32(item["IdProvincia"]));
                        return new Canton(Convert.ToInt32(item["IdCanton"]), provincia, item["Descripcion"]?.ToString());
                    })
                    .ToList();

                return cantones;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al obtener cantones: {e.Message}");
                return null;
            }
        }

        private async Task<List<Distrito>> ObtenerDistritos(List<Canton> cantones)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(UrlDistrito);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JArray jsonResponse = JArray.Parse(responseBody);

                List<Distrito> distritos = jsonResponse
                    .Where(item => cantones.Any(c => c.Id == Convert.ToInt32(item["IdCanton"])))
                    .Select(item =>
                    {
                        var canton = cantones.First(c => c.Id == Convert.ToInt32(item["IdCanton"]));
                        return new Distrito(Convert.ToInt32(item["IdDistrito"]), canton, item["Descripcion"]?.ToString());
                    })
                    .ToList();

                return distritos;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al obtener distritos: {e.Message}");
                return null;
            }
        }
    }
}
