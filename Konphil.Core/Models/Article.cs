using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konphil.Core.Models
{
    public class Article
    {
        [PrimaryKey, AutoIncrement]
        public int ArticleId { get; set; }
        public Market Market { get; set; }
        public string ArticleName { get; set; }
    
        public string Description { get; set; }
        public string Image_Url { get; set; }
        public string ArticleUrl { get; set; }

        public double Price { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return ArticleName;
        }
    }
    public enum ArtciclesOrder
    {
        NameA,
        NameZ,
        LowerPrice,
        HigherPrice,
        Relevance,
        BestSeller
    }
}
