using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Compras.View;
using Compras.Helper;

using System.IO;

namespace Compras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper database;
        public static SQLiteDatabaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteDatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.
                               SpecialFolder.LocalApplicationData), "Compras.db3"));
                }

                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Cadastro());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}