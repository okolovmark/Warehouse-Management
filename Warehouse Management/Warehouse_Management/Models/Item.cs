using SQLite.Net.Attributes;

namespace Warehouse_Management.Models
{
    [Table("Items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Count { get; set; }

        public Item() { }

        public Item(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
}
