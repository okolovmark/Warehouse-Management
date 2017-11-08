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
    public partial class OrderListPage : ContentPage
    {
        public OrderListPage()
        {
            InitializeComponent();
            BindingContext = new OrderListViewModel() { Navigation = this.Navigation };
        }
    }
}
