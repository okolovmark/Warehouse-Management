using System.IO;
using Windows.Storage;
using SQLite.Net.Interop;
using SQLite.Net.Platform.WinRT;
using Xamarin.Forms;
using Warehouse_Management.Models.Interfaces;
using Warehouse_Management.UWP.Models;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace Warehouse_Management.UWP.Models
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }

        public ISQLitePlatform GetDatabasePlatform()
        {
            var platform = new SQLitePlatformWinRT();

            return platform;
        }

        public string GetDatabasePath(string sqliteFilename)
        {
            // для доступа к файлам используем API Windows.Storage
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            return path;
        }
    }
}