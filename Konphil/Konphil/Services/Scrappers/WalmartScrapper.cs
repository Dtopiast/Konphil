using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konphil.Models.ArticleModels;

namespace Konphil.Services.Scrappers
{
    internal class WalmartScrapper : IScrapper
    {
        private readonly string page = "https://super.walmart.com.mx/productos?Ntt=";

        public async Task<List<Article>> Scrapper(string product, ArtciclesOrder order, int amount, int numberpage = 0)
        {
            string url = page;

            if (product.Contains(" "))
            {
                url += product.Replace(" ", "%20");
            }

            var results = new List<Article>();



            HtmlWeb html = new HtmlWeb()
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.74 Safari/537.36",
                UsingCacheIfExists = true,
                UseCookies = true,
            };
            HtmlDocument doc = await html.LoadFromWebAsync(url);
            string y = doc.ParsedText;
            var tablebooks = doc.DocumentNode.CssSelect(".product_container__1TbrZ grid_productBox__31wIF");
            foreach (var tablebook in tablebooks)
            {
                Article article = new();
                try
                {
                    article.ArticleName = tablebook.CssSelect(".product_name__3ID6d").CssSelect(".product_name__1DG9d product_link__bv4qr").CssSelect("p").First().InnerHtml;
                    article.Date = DateTime.Now;
                    article.Price = Convert.ToDouble(tablebook.CssSelect(".text_text__3qcEt text_inline__2hw9E text_bold__2G1zI").First().InnerHtml.Replace("$", ""));
                    article.Image_Url = tablebook.CssSelect(".image_image__mGFxl").CssSelect("src").First().InnerHtml;
                    results.Add(article);
                }
                catch
                {

                }

            }
            return results;
        }
    }
}
