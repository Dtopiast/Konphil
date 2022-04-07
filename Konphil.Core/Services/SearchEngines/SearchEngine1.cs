using Konphil.Core.Models;
using Konphil.Core.Services.Scrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konphil.Core.Services.SearchEngines
{

    public class SearchEngine1 : ISearchEngine
    {
        private readonly IScrapper _chedrauiScrapper;
        private readonly IScrapper _walmartScrapper;
        private readonly IScrapper _sorianaScrapper;

        public SearchEngine1()
        {
            _chedrauiScrapper = new ChedrauiScrapper();
            _walmartScrapper = new WalmartScrapper();
            _sorianaScrapper = new SorianaScrapper();
        }
        public Task<ResultSearch> SearchAsync(Search search)
        {
            throw new NotImplementedException();
        }
    }
}
