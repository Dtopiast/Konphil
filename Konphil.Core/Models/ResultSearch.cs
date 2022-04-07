using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konphil.Core.Models
{
    public class ResultSearch
    {
        public ResultSearchResultType Code { get; set; }
        public Market Market { get; set; }
        public string ArticleName { get; set; }
        public ArtciclesOrder Order { get; set; }
        public int Page { get; set; }
        public int Articles_Num { get; set; }
        public List<Article> Articles { get; set; }

    }
    public enum ResultSearchResultType
    {
        Success,
        NameWithSpecialCharacters,
        ArticleNotFound,
        ExceededPage,
        UknownError,
    }
}
