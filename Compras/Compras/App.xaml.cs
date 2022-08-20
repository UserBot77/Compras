using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Compras.View;

namespace Compras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationPage Cadastro = new NavigationPage();
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
