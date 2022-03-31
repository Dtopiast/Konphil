using Konphil.Services;
using Konphil.Services.Scrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using static Konphil.Helpers.EnumExtensions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Konphil.Models.ResultsModels;
using Konphil.Models.ArticleModels;
using Konphil.Models.MarketModels;
using Konphil.Models.SearchModels;
namespace Konphil.Services.SearchEngine
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

        public async Task<ResultSearch> SearchAsync(Search search)
        {
            var response = new ResultSearch()
            {
                Market =search.Market,
                Order = search.Order,
                Page = search.Page,
            };

            if (Regex.Match(search.Article, @"^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$").Success)
                response.ArticleName = search.Article;
            else
            {
                response.ArticleName = search.Article;
                response.Articles = new List<Article>();
                response.Articles_Num = 0;
                response.Code = ResultSearchResultType.NameWithSpecialCharacters;
                return response;
            }

            response.Order = search.Order;
            response.Market = search.Market;
            if (search.Page < 10)
            {
                response.ArticleName = search.Article;
                response.Articles = new List<Article>();
                response.Articles_Num = 0;
                response.Code = ResultSearchResultType.ExceededPage;
                return response;
            }
            response.Page = search.Page;

            switch (search.Market)
            {
                case Market.Walmart:
                    {
                        response.Articles = await _walmartScrapper.Scrapper(search.Article, search.Order, 10, search.Page);
                        response.Articles_Num = response.Articles.Count();
                        if (response.Articles_Num == 0)
                            response.Code = ResultSearchResultType.ArticleNotFound;
                        else
                            response.Code = ResultSearchResultType.Success;
                    }
                    break;
                case Market.Chedraui:
                    {
                        response.Articles = await _chedrauiScrapper.Scrapper(search.Article, search.Order, 24, search.Page);
                        response.Articles_Num = response.Articles.Count();
                        if (response.Articles_Num == 0)
                            response.Code = ResultSearchResultType.ArticleNotFound;
                        else
                            response.Code = ResultSearchResultType.Success;
                    }
                    break;
                case Market.Soriana:
                    {
                        response.Articles = await _sorianaScrapper.Scrapper(search.Article, search.Order, 10, search.Page);
                        response.Articles_Num = response.Articles.Count();
                        if (response.Articles_Num == 0)
                            response.Code = ResultSearchResultType.ArticleNotFound;
                        else
                            response.Code = ResultSearchResultType.Success;
                    }
                    break;
                case Market.All:
                    {
                        response.Articles.AddRange(await _chedrauiScrapper.Scrapper(search.Article, search.Order, 10, search.Page));
                        response.Articles.AddRange(await _sorianaScrapper.Scrapper(search.Article, search.Order, 10, search.Page));
                        response.Articles.AddRange(await _walmartScrapper.Scrapper(search.Article, search.Order, 10, search.Page));
                        response.Articles.OrderArticles(search.Order);

                        response.Articles_Num = response.Articles.Count();
                        if (response.Articles_Num == 0)
                            response.Code = ResultSearchResultType.ArticleNotFound;
                        else
                            response.Code = ResultSearchResultType.Success;
                    }
                    break;
                default:
                    break;
            }
            return response;

        }
    }
    public static class AutoComplete
    {
        public static void OrderArticles(this List<Article> value, ArtciclesOrder order)
        {
            switch (order)
            {
                case ArtciclesOrder.NameA:
                    value.OrderBy(x => x.ArticleName);
                    break;
                case ArtciclesOrder.NameZ:
                    value.OrderByDescending(x => x.ArticleName);
                    break;
                case ArtciclesOrder.LowerPrice:
                    value.OrderBy(x => x.Price);
                    break;
                case ArtciclesOrder.HigherPrice:
                    value.OrderByDescending(x => x.Price);
                    break;
                case ArtciclesOrder.Relevance:
                    //a crear
                    break;
                case ArtciclesOrder.BestSeller:
                    //a crear
                    break;
                default:
                    break;
            }
        }
    }
}
