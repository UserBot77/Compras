using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Compras.Models;

namespace Compras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        ObservableCollection<Item> I = new ObservableCollection<Item>();
        public Lista()
        {
            InitializeComponent();

            lista_items.ItemsSource = I;
        }

        private void atualizando_Refreshing(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Run(async () =>
            {
                List<Item> temp = await App.Database.GetAllRows();

                I.Clear();

                foreach (Item item in temp)
                {
                    I.Add(item);
                }

                atualizando.IsRefreshing = false;
            });
        }

        protected override void OnAppearing()
        {
            if (I.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Item> temp = await App.Database.GetAllRows();

                    foreach (Item item in temp)
                    {
                        I.Add(item);
                    }

                    atualizando.IsRefreshing = false;
                });

                lista_items.ItemsSource = I;
            }
        }

        private async void lista_items_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Item item_selecionado = (Item)e.SelectedItem;

            Navigation.PushAsync(new Lista
            {
                BindingContext = item_selecionado
            });

            await Navigation.PushAsync(new ExibirItem());
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastro());
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busca = e.NewTextValue;

            System.Threading.Tasks.Task.Run(async () =>
            {
                List<Item> temp = await App.Database.Search(busca);

                I.Clear();

                foreach (Item item in temp)
                {
                    I.Add(item);
                }

                atualizando.IsRefreshing = false;
            });
        }
    }
}