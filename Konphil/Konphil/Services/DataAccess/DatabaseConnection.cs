using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Konphil.Models.ArticleModels;

namespace Konphil.Services.DataAccess
{
    public class DatabaseConnection
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseConnection(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Article>();
        }

        public Task<List<Article>> GetArticlesAsync()
        {
            return _database.Table<Article>().ToListAsync();
        }

        public Task<int> SaveArticleAsync(Article Article)
        {
            return _database.InsertAsync(Article);
        }

        public Task<int> UpdateArticleAsync(Article Article)
        {
            return _database.UpdateAsync(Article);
        }

        public Task<int> DeleteArticleAsync(Article Article)
        {
            return _database.DeleteAsync(Article);
        }

        public Task<Article> GetArticleAsync(int id)
        {
            return _database.Table<Article>().FirstOrDefaultAsync(x => x.ArticleId == id);
        }

        //public Task<List<Article>> LinqNotSubscribedAsync()
        //{
        //    //return _database.Table<Article>().Where(p => p.Subscribed == false).ToListAsync();
        //}
    }
}
