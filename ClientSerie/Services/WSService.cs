using ClientSerie.Models;
using ClientSerie.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using HttpClient = System.Net.Http.HttpClient;

namespace ClientConvertisseurV2.Services
{
    public class WSService : IService
    {
        private HttpClient client;

        public WSService(string url)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(url);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }

        public async Task<List<Serie>> DeleteSerieAsync(string nomControleur)
        {
            try
            {
                return await Client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Serie>> GetAllSerieAsync(string nomControleur)
        {
            try
            {
                return await Client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Serie> GetSerieAsync(string nomControleur, int id)
        {
            try
            {
                return await Client.GetFromJsonAsync<Serie>(string.Concat(nomControleur + "/" + id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Serie>> PostSerieAsync(string nomControleur)
        {
            try
            {
                return await Client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Serie>> PutSerieAsync(string nomControleur)
        {
            try
            {
                return await Client.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}