using System;
using System.ComponentModel;
using SQLite.Net.Attributes;
using Warehouse_Management.Models;

namespace Warehouse_Management.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ItemsListViewModel lvm;

        public Item Item { get; private set; }

        public ItemViewModel()
        {
            Item = new Item();
        }

        public ItemViewModel(string name, int count)
        {
            Item = new Item(name, count);
        }

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

        public int Id
        {
            get { return Item.Id; }
            set
            {
                if (Item.Id != value)
                {
                    Item.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

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
