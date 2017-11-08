using System;
using Warehouse_Management.Models;
using Warehouse_Management.Views;
using Xamarin.Forms;

namespace Warehouse_Management
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Items2.db";

        public static ItemRepository database;
        public static ItemRepository id;

        public static int Id
        {
            get
            {
                //App.Current.Properties.Remove("id");
                object id = "";
                if (App.Current.Properties.TryGetValue("id", out id))
                {
                    string temp1 = (string) id;
                    int temp2 = Int32.Parse(temp1);
                    return temp2;
                }
                App.Current.Properties.Add("id", "1");
                return Int32.Parse(App.Current.Properties["id"] as string);
            }
        }

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
