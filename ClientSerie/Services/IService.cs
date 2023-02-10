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
        Task<List<Serie>> GetSerieAsync(string nomControleur);
        Task<List<Serie>> PutSerieAsync(string nomControleur);
        Task<List<Serie>> PostSerieAsync(string nomControleur);
        Task<List<Serie>> DeleteSerieAsync(string nomControleur);
        
    }
}