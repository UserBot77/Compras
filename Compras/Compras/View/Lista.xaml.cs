using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Compras.Models;
using System.Collections.ObjectModel;

namespace Compras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        ObservableCollection<Item> Lista_Items = new ObservableCollection<Item>();
        public Lista()
        {
            InitializeComponent();
        }

        private void txt_Buscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem Excluir = (MenuItem)sender;
            Item MenuProduto = (Item)Excluir.BindingContext;

            bool Confirmacao = await DisplayAlert("Essa ação removerá permanentemente", "Remover Item?", "Sim", "Não");

            if(Confirmacao)
            {
                await App.Database.Delete(MenuProduto.Id);
                Lista_Items.Remove(MenuProduto);
            }
        }
    }
}