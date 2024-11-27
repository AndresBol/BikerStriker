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

        /*
        public static async Task<Provincia> ObtenerProvincia(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(UrlProvincia);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JArray jsonResponse = JArray.Parse(responseBody);

                List<Provincia> provincias = new List<Provincia>();

                foreach (var item in jsonResponse)
                {
                    int idProvincia = Convert.ToInt32(item["IdProvincia"]?.ToString());
                    if (idProvincia == id)
                    {
                        return new Provincia(idProvincia, item["Descripcion"]?.ToString()); ;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error inesperado: {e.Message}");
                return null;
            }
        }

        public static async Task<Canton> ObtenerCanton(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(UrlCanton);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JArray jsonResponse = JArray.Parse(responseBody);

                foreach (var item in jsonResponse)
                {
                    int idCanton = Convert.ToInt32(item["IdCanton"]?.ToString());
                    if (idCanton == id)
                    {
                        return new Canton(idCanton, await ObtenerProvincia(Convert.ToInt32(item["idProvincia"]?.ToString())), item["Descripcion"]?.ToString()); ;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error inesperado: {e.Message}");
                return null;
            }
        }

        public static async Task<Distrito> ObtenerDistrito(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(UrlDistrito);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JArray jsonResponse = JArray.Parse(responseBody);

                foreach (var item in jsonResponse)
                {
                    int idDistrito = Convert.ToInt32(item["IdDistrito"]?.ToString());
                    if (idDistrito == id)
                    {
                        return new Distrito(idDistrito, await ObtenerCanton(Convert.ToInt32(item["idCanton"]?.ToString())), item["Descripcion"]?.ToString()); ;
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error inesperado: {e.Message}");
                return null;
            }
        }

        public static async Task<List<Provincia>> ObtenerProvincias()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(UrlProvincia);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JArray jsonResponse = JArray.Parse(responseBody);

                List<Provincia> provincias = new List<Provincia>();

                foreach (var item in jsonResponse)
                {
                    Provincia provincia = new Provincia(Convert.ToInt32(item["IdProvincia"]?.ToString()), item["Descripcion"]?.ToString());
                    provincias.Add(provincia);
                }

                return provincias;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error inesperado: {e.Message}");
                return null;
            }
        }

        public static async Task<List<Canton>> ObtenerCantones(Provincia provincia)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(UrlCanton);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JArray jsonResponse = JArray.Parse(responseBody);

                List<Canton> cantones = new List<Canton>();

                foreach (var item in jsonResponse)
                {

                    if (provincia.Id == Convert.ToInt32(item["IdProvincia"]?.ToString()))
                    {
                        Canton canton = new Canton(Convert.ToInt32(item["IdCanton"]?.ToString()), provincia, item["Descripcion"]?.ToString());
                        cantones.Add(canton);
                    }
                }

                return cantones;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error inesperado: {e.Message}");
                return null;
            }
        }

        public static async Task<List<Canton>> ObtenerCantones(List<Provincia>)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(UrlCanton);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JArray jsonResponse = JArray.Parse(responseBody);

                List<Canton> cantones = new List<Canton>();

                foreach (var item in jsonResponse)
                {
                        Canton canton = new Canton(Convert.ToInt32(item["IdCanton"]?.ToString()), , item["Descripcion"]?.ToString());
                        cantones.Add(canton);
                }

                return cantones;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error inesperado: {e.Message}");
                return null;
            }
        }

        public static async Task<List<Distrito>> ObtenerDistritos(Canton canton)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(UrlDistrito);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JArray jsonResponse = JArray.Parse(responseBody);

                List<Distrito> distritos = new List<Distrito>();

                foreach (var item in jsonResponse)
                {

                    if (canton.Id == Convert.ToInt32(item["IdCanton"]?.ToString()))
                    {
                        Distrito distrito = new Distrito(Convert.ToInt32(item["IdDistrito"]?.ToString()), canton, item["Descripcion"]?.ToString());
                        distritos.Add(distrito);
                    }
                }

                return distritos;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error inesperado: {e.Message}");
                return null;
            }
        }
        public static async Task<List<Distrito>> ObtenerDistritos()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(UrlDistrito);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JArray jsonResponse = JArray.Parse(responseBody);

                List<Distrito> distritos = new List<Distrito>();

                foreach (var item in jsonResponse)
                {

                    if (canton.Id == Convert.ToInt32(item["IdCanton"]?.ToString()))
                    {
                        Distrito distrito = new Distrito(Convert.ToInt32(item["IdDistrito"]?.ToString()), canton, item["Descripcion"]?.ToString());
                        distritos.Add(distrito);
                    }
                }

                return distritos;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error inesperado: {e.Message}");
                return null;
            }
        }
    }*/
