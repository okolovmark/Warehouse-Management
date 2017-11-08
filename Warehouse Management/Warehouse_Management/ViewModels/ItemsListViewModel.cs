using System;
using Warehouse_Management.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Linq;
using Warehouse_Management.Models;

namespace Warehouse_Management.ViewModels
{
   
    public class ItemsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ItemViewModel> Items { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand EditItemCommand { get; }
        public ICommand SaveItemCommand { get; }
        public ICommand BackCommand { get; }

        private ItemViewModel _selectedItem;

        public INavigation Navigation { private get; set; }

        public ItemsListViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();
            foreach (var item in App.Database.GetItems())
            {
                Items.Add(ConvertToItemViewModel(item));
            }
            CreateItemCommand = new Command(CreateItem);
            EditItemCommand = new Command(EditItem);
            DeleteItemCommand = new Command(DeleteItem);
            SaveItemCommand = new Command(SaveItem);
            BackCommand = new Command(Back);
        }

        private ItemViewModel ConvertToItemViewModel(Item item)
        {
            var tempivm = new ItemViewModel
                          {
                              Name = item.Name,
                              Count = item.Count,
                              Id = item.Id,
                              ListViewModel = this
                          };
            return tempivm;
        }

        private static Item ConvertToItem(ItemViewModel ivm)
        {
            var tempitem = new Item
                           {
                               Name = ivm.Name,
                               Count = ivm.Count,
                               Id = ivm.Id
                           };
            return tempitem;
        }

        public ItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem == value) return;
                var tempItem = value;
                _selectedItem = null;
                OnPropertyChanged("SelectedItem");
                Navigation.PushAsync(new EditItemPage(tempItem));
            }
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateItem()
        {
            Navigation.PushAsync(new CreateItemPage(new ItemViewModel { ListViewModel = this }));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }
            
        private void SaveItem(object itemObject)
        {
            var item = itemObject as ItemViewModel;
            if (item != null && item.IsValid)
            {
                item.Id = App.Id;
                App.Current.Properties["id"] = (Int32.Parse(App.Current.Properties["id"] as string) + 1).ToString();
                App.Database.SaveItem(ConvertToItem(item));
                Items.Add(item);
            }
            Back();
        }

        private void DeleteItem(object itemObject)
        {
            var item = itemObject as ItemViewModel;
            if (item != null)
            {
                Items.Remove(item);
                App.Database.DeleteItem(ConvertToItem(item).Id);   
            }
            Back();
        }

        private void EditItem(object itemObject)
        {
            var item = itemObject as ItemViewModel;
            if (item.IsValid)
            {
                var temp = Items.FirstOrDefault(it => it.Name == item.Name);
                Items[Items.IndexOf(temp)].Count = item.Count;
                App.Database.UpdateItem(ConvertToItem(item));
            }
            Back();
        }
    }
}
