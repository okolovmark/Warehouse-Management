using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Warehouse_Management.Annotations;
using Warehouse_Management.Models;
using Warehouse_Management.Views;
using Xamarin.Forms;

namespace Warehouse_Management.ViewModels
{
    public class StartViewModel
    {
        public ICommand SaveItemCommand { get; }
        public ICommand CreateItemCommand { get; }
        public ICommand OpenInStockCommand { get; }
        public ICommand OpenToOrderCommand { get; }
        public INavigation Navigation { private get; set; }

        public StartViewModel()
        {
            SaveItemCommand = new Command(SaveItem);
            CreateItemCommand = new Command(CreateItem);
            OpenInStockCommand = new Command(OpenInStock);
            OpenToOrderCommand = new Command(OpenToOrder);
        }

        private void CreateItem()
        {
            Navigation.PushAsync(new CreateItemPage());
        }

        //private void SaveItem(object itemObject)
        //{
        //    var item = itemObject as ItemViewModel;
        //    if (item != null && item.IsValid)
        //    {
        //        /*item.Id = */
        //        App.Database.SaveItem(ConvertToItem(item));
        //        //App.Current.Properties["id"] = (Int32.Parse(App.Current.Properties["id"] as string) + 1).ToString();
        //        //App.Database.SaveItem(ConvertToItem(item));
        //        Items.Add(item);
        //    }
        //    Back();
        //}

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

        private void SaveItem(object itemObject)
        {
            var item = itemObject as ItemViewModel;
            if (item != null && item.IsValid)
            {
                App.Database.SaveItem(ConvertToItem(item));
            }
            Navigation.PopAsync();
        }

        private void OpenInStock()
        {
            Navigation.PushAsync(new ItemsListPage());
        }

        private void OpenToOrder()
        {
            Navigation.PushAsync(new OrderListPage());
        }
    }
}