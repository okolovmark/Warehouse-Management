
using Warehouse_Management.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Warehouse_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateItemPage : ContentPage
    {
        public ItemViewModel ViewModel { get; private set; }
        public CreateItemPage(ItemViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}
