using System;
using System.IO;
using SQLite.Net.Interop;
using Warehouse_Management.Droid.Models;
using Warehouse_Management.Models.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Warehouse_Management.Droid.Models
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        public ISQLitePlatform GetDatabasePlatform()
        {
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

            return platform;
        }

        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}