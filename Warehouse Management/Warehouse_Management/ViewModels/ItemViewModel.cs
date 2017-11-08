using System;
using System.ComponentModel;
using SQLite.Net.Attributes;
using Warehouse_Management.Models;

namespace Warehouse_Management.ViewModels
{
    [Table("Items")]
    public class ItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ItemsListViewModel lvm;

        [Ignore]
        public Item Item { get; private set; }

        public ItemViewModel()
        {
            Item = new Item();
        }

        public ItemViewModel(string name, int count)
        {
            Item = new Item(name, count);
        }

        [Ignore]
        public ItemsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get { return Item.Name; }
            set
            {
                if (Item.Name != value)
                {
                    Item.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public int Count
        {
            get { return Item.Count; }
            set
            {
                if (Item.Count != value)
                {
                    Item.Count = value;
                    OnPropertyChanged("Count");
                }
            }
        }

        [Ignore]
        public bool IsValid
        {
            get
            {
                try
                {
                    return ((!string.IsNullOrEmpty(Name.Trim())) &&
                            (Count != 0));
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
