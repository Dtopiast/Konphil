using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konphil.Models.ArticleModels;

namespace Konphil.Services.Scrappers
{
    internal interface IScrapper
    {
        public Task<List<Article>> Scrapper(string product, ArtciclesOrder order, int amount, int numberpage = 0);

    }
}
