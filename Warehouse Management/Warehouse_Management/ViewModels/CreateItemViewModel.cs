using System;
using System.ComponentModel;
using System.Windows.Input;
using Warehouse_Management.Models;
using Xamarin.Forms;

namespace Warehouse_Management.ViewModels
{
    public class CreateItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name { get; set; }
        private int _count { get; set; }
        private bool _bought { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                if (_count == value) return;
                _count = value;
                OnPropertyChanged("Count");
            }
        }

        public bool Bought
        {
            get => _bought;
            set
            {
                if (_bought == value) return;
                _bought = value;
                OnPropertyChanged("Bought");
            }
        }

        public ICommand SaveItemCommand { get; }
        public INavigation Navigation { private get; set; }
        public CreateItemViewModel()
        {
            SaveItemCommand = new Command(SaveItem);
        }

        private static Item ConvertToItem(ItemViewModel ivm)
        {
            var tempitem = new Item
                           {
                               Name = ivm.Name,
                               Count = ivm.Count,
                               Id = ivm.Id,
                               Bought = ivm.Bought
                           };
            return tempitem;
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void SaveItem(object itemObject)
        {
            var  temp = itemObject as CreateItemViewModel;
            var item = new ItemViewModel();
            item.Name = temp.Name;
            item.Count = temp.Count;
            item.Bought = temp.Bought;
            if (item != null && item.IsValid)
            {
                App.Database.SaveItem(ConvertToItem(item));
            }
            Navigation.PopAsync();
        }
    }
}