using Konphil.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konphil.Core.Services.Scrappers
{
    public class SorianaScrapper : IScrapper
    {
        public Task<List<Article>> Scrapper(string product, ArtciclesOrder order, int amount, int numberpage = 0)
        {
            throw new NotImplementedException();
        }
    }
}
