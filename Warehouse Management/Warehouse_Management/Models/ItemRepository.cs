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
        SQLiteConnection database;

        public ItemRepository(string filename)
        {
            var sqlitePlatform = DependencyService.Get<ISQLite>().GetDatabasePlatform();
            var databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(sqlitePlatform, databasePath);
            database.CreateTable<ItemViewModel>();
        }
        public IEnumerable<ItemViewModel> GetItems()
        {
            return (from i in database.Table<ItemViewModel>() select i).ToList();

        }
        public ItemViewModel GetItem(int id)
        {
            return database.Get<ItemViewModel>(id);
        }
        public int DeleteItem(ItemViewModel item)
        {
            return database.Delete(item);
        }
        public int UpdateItem(ItemViewModel item)
        {
            return database.Update(item);
        }
        public int SaveItem(ItemViewModel item)
        {
            return database.Insert(item);
        }
    }
}