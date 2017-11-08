using SQLite.Net.Interop;

namespace Warehouse_Management.Models.Interfaces
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
        ISQLitePlatform GetDatabasePlatform();
    }
}