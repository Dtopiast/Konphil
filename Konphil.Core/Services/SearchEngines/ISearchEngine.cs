using Konphil.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konphil.Core.Services.SearchEngines
{
    public interface ISearchEngine
    { 
        public Task<ResultSearch> SearchAsync(Search search);
    }
}
