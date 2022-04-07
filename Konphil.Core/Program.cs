using System;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Konphil.Core.Models;
using Konphil.Core.Services.Scrappers;

namespace Konphil.Core
{

    public class Program
    {


        public static async Task Main()
        {
            
            IScrapper  y = new ChedrauiScrapper();
            var result = await y.Scrapper("tomate",ArtciclesOrder.BestSeller,20);
         
        result.ForEach(x=>Console.WriteLine(x.ArticleName));
            Console.Read();
            
        }
        
    }
}

