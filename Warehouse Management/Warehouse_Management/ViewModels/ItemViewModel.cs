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
        private OrderListViewModel ovm;

        public Item Item { get; private set; }

        public ItemViewModel()
        {
            Item = new Item();
        }

        public ItemsListViewModel ListViewModel
        {
            get => lvm;
            set
            {
                if (lvm == value) return;
                lvm = value;
                OnPropertyChanged("ListViewModel");
            }
        }

        public OrderListViewModel OrderViewModel
        {
            get => ovm;
            set
            {
                if (ovm == value) return;
                ovm = value;
                OnPropertyChanged("OrderViewModel");
            }
        }

        public string Name
        {
            get => Item.Name;
            set
            {
                if (Item.Name == value) return;
                Item.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Count
        {
            get => Item.Count;
            set
            {
                if (Item.Count == value) return;
                Item.Count = value;
                OnPropertyChanged("Count");
            }
        }

        public bool Bought
        {
            get => Item.Bought;
            set
            {
                if (Item.Bought == value) return;
                Item.Bought = value;
                OnPropertyChanged("Bought");
            }
        }

        public int Id
        {
            get => Item.Id;
            set
            {
                if (Item.Id == value) return;
                Item.Id = value;
                OnPropertyChanged("Id");
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

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
