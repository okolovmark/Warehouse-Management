using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Management.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Warehouse_Management.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditOrderItemPage : ContentPage
    {
        public ItemViewModel ViewModel { get; private set; }

        public EditOrderItemPage()
        {
            InitializeComponent();
        }
        public EditOrderItemPage(ItemViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}
