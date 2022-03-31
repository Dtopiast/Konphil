using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Konphil.Models.ArticleModels;
using Konphil.Models.MarketModels;
using ScrapySharp.Extensions;

namespace Konphil.Services.Scrappers
{
    public class ChedrauiScrapper :IScrapper
    {
        private readonly string Url_base = "https://www.chedraui.com.mx/search?sort=";
        private readonly string url_img_base = "https://www.chedraui.com.mx";
        private readonly string useragent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.74 Safari/537.36";

        public async Task<List<Article>> Scrapper(string product,ArtciclesOrder order, int amount,int numberpage = 0)
        {
            StringBuilder stringBuilder = new StringBuilder(Url_base);

            switch (order)
            {
                case ArtciclesOrder.NameA:
                    {
                        stringBuilder.Append("name-asc");
                    }
                    break;
                case ArtciclesOrder.NameZ:
                    {
                        stringBuilder.Append("name-desc");
                    }
                    break;
                case ArtciclesOrder.LowerPrice:
                    {
                        stringBuilder.Append("price-asc");
                    }
                    break;
                case ArtciclesOrder.HigherPrice:
                    {
                        stringBuilder.Append("price-desc");
                    }
                    break;
                case ArtciclesOrder.Relevance:
                    {
                        stringBuilder.Append("relevance");
                    }
                    break;
                case ArtciclesOrder.BestSeller:
                    {
                        stringBuilder.Append("mostSold");
                    }
                    break;
                default:
                    break;
            }
  
            if (product.Contains(" "))
                product.Replace(" ", "%20");
            stringBuilder.Append("&q="+product);

            if (numberpage >= 1)
                stringBuilder.Append($"&page={numberpage}"); 

            var results = new List<Article>();

            HtmlWeb html = new HtmlWeb()
            {
                UserAgent = useragent,
                UsingCacheIfExists = true,
                UseCookies = true,
            };
            HtmlDocument doc = await html.LoadFromWebAsync(stringBuilder.ToString());

            var date = DateTime.Now;
            var tablebooks = doc.DocumentNode.CssSelect(".product__list--item");
            foreach (var tablebook in tablebooks)
            {
                Article article = new();
                try
                {                
                    article.ArticleName = tablebook.CssSelect(".product__list--name").First().InnerHtml;
                    article.Date = date;
                    article.Price = Convert.ToDouble(tablebook.CssSelect(".price-colour-final").First().InnerHtml.Replace("$", ""));
                    article.Market = Market.Chedraui;
                    article.Description = tablebook.CssSelect(".col-md-4").CssSelect(".row").CssSelect("p").First().InnerHtml;
                    article.Image_Url = url_img_base + tablebook.CssSelect("img").First().Attributes["src"].Value.ToString();
                    results.Add(article);
                }
                catch
                {
                }
            }
           
            if (results.Count() == 0)
                return results;
            if (results.Count() <= amount)
                return results;
            else
                return results.Chunk(amount).First().ToList();
        }
    }
}
