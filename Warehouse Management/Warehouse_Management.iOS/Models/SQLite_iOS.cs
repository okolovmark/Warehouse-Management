using System;
using System.IO;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using Warehouse_Management.iOS.Models;
using Warehouse_Management.Models.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace Warehouse_Management.iOS.Models
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }
        public ISQLitePlatform GetDatabasePlatform()
        {
            var platform = new SQLitePlatformIOS();

            return platform;
        }

        public string GetDatabasePath(string sqliteFilename)
        {
            // определяем путь к бд
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // папка библиотеки
            var path = Path.Combine(libraryPath, sqliteFilename);

            return path;
        }
    }
}