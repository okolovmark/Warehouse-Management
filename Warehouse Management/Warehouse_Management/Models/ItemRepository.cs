using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using Warehouse_Management.Models.Interfaces;
using Warehouse_Management.ViewModels;
using Xamarin.Forms;

namespace Warehouse_Management.Models
{
    public class ItemRepository
    {
        SQLiteConnection _database;

        public ItemRepository(string filename)
        {
            var sqlitePlatform = DependencyService.Get<ISQLite>().GetDatabasePlatform();
            var databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            _database = new SQLiteConnection(sqlitePlatform, databasePath);
            _database.CreateTable<Item>();
        }
        public IEnumerable<Item> GetItems()
        {
            return (from i in _database.Table<Item>() select i).ToList();

        }
        public Item GetItem(int id)
        {
            return _database.Get<Item>(id);
        }
        public int DeleteItem(int id)
        {
            return _database.Delete<Item>(id);
        }
        public int UpdateItem(Item item)
        {
            _database.Update(item);
            return item.Id;
        }
        public int SaveItem(Item item)
        {
            return _database.Insert(item);
        }
    }
}