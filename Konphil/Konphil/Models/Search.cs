//using SQLite;
using Konphil.Models.MarketModels;
using Konphil.Models.ArticleModels;

namespace Konphil.Models.SearchModels
{
    public class Search
    {
       // [PrimaryKey, AutoIncrement]
        public int SearchId { get; set; }
        public string Article { get; set; }
        public Market Market { get; set; }
        public ArtciclesOrder Order { get; set; }
        public int Page { get; set; }
    }
}
