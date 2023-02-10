using ClientSerie.Models;
using ClientSerie.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Services
{
    internal interface IService
    {
        Task<List<Serie>> GetAllSerieAsync(string nomControleur);
        Task<Serie> GetSerieAsync(string nomControleur, int id);
        Task<Boolean> PutSerieAsync(string nomControleur, Serie s);
        Task<Boolean> PostSerieAsync(string nomControleur);
        Task<Boolean> DeleteSerieAsync(string nomControleur, int id);
        
    }
}