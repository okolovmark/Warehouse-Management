using Warehouse_Management.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Linq;

namespace Warehouse_Management.ViewModels
{
   
    public class ItemsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ItemViewModel> Items { get; set; }

        private int _indexOfEditingItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateItemCommand { protected set; get; }
        public ICommand DeleteItemCommand { protected set; get; }
        public ICommand EditItemCommand { protected set; get; }
        public ICommand AcceptEditItemCommand { protected set; get; }
        public ICommand SaveItemCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        ItemViewModel selectedItem;

        public INavigation Navigation { get; set; }

        public ItemsListViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();
            CreateItemCommand = new Command(CreateItem);
            EditItemCommand = new Command(EditItem);
            AcceptEditItemCommand = new Command(AcceptEditItem);
            DeleteItemCommand = new Command(DeleteItem);
            SaveItemCommand = new Command(SaveItem);
            BackCommand = new Command(Back);
        }

        public ItemViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    ItemViewModel tempItem = value;
                    selectedItem = null;
                    OnPropertyChanged("SelectedItem");
                    Navigation.PushAsync(new CreateItemPage(tempItem));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateItem()
        {
            Navigation.PushAsync(new CreateItemPage(new ItemViewModel() { ListViewModel = this }));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveItem(object ItemObject)
        {
            ItemViewModel item = ItemObject as ItemViewModel;
            if (item != null && item.IsValid)
            {
                Items.Add(item);
            }
            Back();
        }

        private void DeleteItem(object ItemObject)
        {
            ItemViewModel item = ItemObject as ItemViewModel;
            if (item != null)
            {
                    Items.Remove(item);
            }
            Back();
        }

        private void EditItem(object ItemObject)
        {
            ItemViewModel item = ItemObject as ItemViewModel;
            Navigation.PushAsync(new EditItemPage(new ItemViewModel(item.Name, item.Count) { ListViewModel = this }));     
        }

        private void AcceptEditItem(object ItemObject)
        {
            ItemViewModel item = ItemObject as ItemViewModel;
            if (item.IsValid)
            {
                var temp = Items.FirstOrDefault(it => it.Name == item.Name);
                Items[Items.IndexOf(temp)].Count = item.Count;
            }
            Back();
        }
    }
}
