using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Warehouse_Management.Annotations;
using Warehouse_Management.Models;
using Warehouse_Management.Views;
using Xamarin.Forms;

namespace Warehouse_Management.ViewModels
{
    public class OrderListViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged( string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public INavigation Navigation { private get; set; }
        public ObservableCollection<ItemViewModel> OrderItems { get; }
        private ItemViewModel _selectedItem;

        public ICommand DeleteItemCommand { get; }
        public ICommand EditItemCommand { get; }
        public ICommand BackCommand { get; }

        public OrderListViewModel()
        {
            OrderItems = new ObservableCollection<ItemViewModel>();
            foreach (var item in App.Database.GetItems())
            {
                if (!item.Bought)
                    OrderItems.Add(ConvertToItemViewModel(item));
            }

            EditItemCommand = new Command(EditItem);
            DeleteItemCommand = new Command(DeleteItem);
            BackCommand = new Command(Back);
        }

        private ItemViewModel ConvertToItemViewModel(Item item)
        {
            var tempivm = new ItemViewModel
                          {
                              Name = item.Name,
                              Count = item.Count,
                              Id = item.Id,
                              Bought = item.Bought,
                              OrderViewModel = this
                          };
            return tempivm;
        }

        private static Item ConvertToItem(ItemViewModel ivm)
        {
            var tempitem = new Item
                           {
                               Name = ivm.Name,
                               Count = ivm.Count,
                               Bought = ivm.Bought,
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
                Navigation.PushAsync(new EditOrderItemPage(tempItem));
            }
        }

        private void Back()
        {
            Navigation.PopAsync();
        }



        private void DeleteItem(object itemObject)
        {
            var item = itemObject as ItemViewModel;
            if (item != null)
            {
                OrderItems.Remove(item);
                App.Database.DeleteItem(ConvertToItem(item).Id);
            }
        }

        private void EditItem(object itemObject)
        {
            var item = itemObject as ItemViewModel;
            if (item.IsValid)
            {
                var temp = OrderItems.FirstOrDefault(it => it.Name == item.Name);
                OrderItems[OrderItems.IndexOf(temp)].Count = item.Count;
                App.Database.UpdateItem(ConvertToItem(item));
            }
            Back();
        }
    }

}