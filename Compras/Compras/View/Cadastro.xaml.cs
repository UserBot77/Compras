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
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Item I = new Item();
            I.Produto = txt_Produto.Text;
            I.Quantidade = Convert.ToDouble(txt_Qntd.Text);
            I.PrecoUnitario = Convert.ToDouble(txt_PrecoUnitario.Text);
            I.Descricao = txt_Descricao.Text;

            await Navigation.PushAsync(new Lista());
        }
    }
}