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

        public Task<List<Serie>> DeleteSerieAsync(string nomControleur)
        {
            throw new NotImplementedException();
        }

        public Task<List<Serie>> GetAllSerieAsync(string nomControleur)
        {
            throw new NotImplementedException();
        }

        public Task<List<Serie>> GetSerieAsync(string nomControleur)
        {
            throw new NotImplementedException();
        }

        public Task<List<Serie>> PostSerieAsync(string nomControleur)
        {
            throw new NotImplementedException();
        }

        public Task<List<Serie>> PutSerieAsync(string nomControleur)
        {
            throw new NotImplementedException();
        }
    }
}