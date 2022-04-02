//using SQLite;
using Konphil.Models.MarketModels;
using Konphil.Models.ArticleModels;
using System.ComponentModel.DataAnnotations;

namespace Konphil.Models.SearchModels
{
    public class Search
    {
       // [PrimaryKey, AutoIncrement]
        public int SearchId { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$", ErrorMessage = "Invalid Article")]
        public string Article { get; set; }
        public Market Market { get; set; }
        public ArtciclesOrder Order { get; set; }
        public int Page { get; set; }
    }
}
