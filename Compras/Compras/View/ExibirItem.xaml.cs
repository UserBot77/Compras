using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Compras.Models;

namespace Compras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExibirItem : ContentPage
    {
        public ExibirItem()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Item i = new Item
            {
                Id = Convert.ToInt16(lbl_id.Text),
                Produto = txt_produto.Text,
                PrecoUnitario = Convert.ToDouble(txt_preco.Text),
                Quantidade = Convert.ToDouble(txt_qntd.Text),
                Descricao = txt_descricao.Text,
            };

            await App.Database.Update(i);

            await Navigation.PushAsync(new Lista());
        }
    }
}