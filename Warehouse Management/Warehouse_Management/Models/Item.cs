namespace Warehouse_Management.Models
{
    public class Item
    {
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
