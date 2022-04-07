using Konphil.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betaphil.Core.Data.DBConnection
{
    public class SQLiteContext : IDisposable, IDBConnection
    {
        public readonly SQLiteAsyncConnection _connection;
        
        public SQLiteContext(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath) ;

            _connection.CreateTableAsync<Article>().Wait();
        }
        public void Dispose()
        {           
            GC.SuppressFinalize(this);
        }
    }
}
