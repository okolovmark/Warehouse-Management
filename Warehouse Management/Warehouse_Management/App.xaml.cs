using Warehouse_Management.Models;
using Warehouse_Management.Views;
using Xamarin.Forms;

namespace Warehouse_Management
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Items.db";
        public static ItemRepository database;

        public static ItemRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemRepository(DATABASE_NAME);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ItemsListPage());
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {

            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
