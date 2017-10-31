using Warehouse_Management.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Warehouse_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditItemPage : ContentPage
    {
        public ItemViewModel ViewModel { get; private set; }
        public EditItemPage(ItemViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}
