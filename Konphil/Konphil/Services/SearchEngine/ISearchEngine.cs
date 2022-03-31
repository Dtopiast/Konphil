using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konphil.Models.ResultsModels;
using Konphil.Models.ArticleModels;
using Konphil.Models.SearchModels;
using Konphil.Models.MarketModels;

namespace Konphil.Services.SearchEngine
{
    public interface ISearchEngine
    {
        public Task<ResultSearch> SearchAsync(Search search);
    }
}
