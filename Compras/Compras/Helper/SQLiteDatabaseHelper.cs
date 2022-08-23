using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Compras.Models;
using System.Threading.Tasks;

namespace Compras.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);

            _conn.CreateTableAsync<Item>().Wait();
        }
        public Task<int> Delete(int id)
        {
            return _conn.Table<Item>().DeleteAsync(i => i.Id == id);
        }
    }
}
