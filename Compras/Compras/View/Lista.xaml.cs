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
            try
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
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }
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

        private void lista_items_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Item item_selecionado = (Item)e.SelectedItem;

            Navigation.PushAsync(new Lista
            {
                BindingContext = item_selecionado
            });
        }
    }
}