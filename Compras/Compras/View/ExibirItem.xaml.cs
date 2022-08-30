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

        public double? GetTotal()
        {
            return total;
        }

        private void Button_Clicked(object sender, EventArgs e, double? total)
        {
            Item i = new Item
            {
                Id = Convert.ToInt16(lbl_id.Text),
                Produto = txt_produto.Text,
                PrecoUnitario = Convert.ToDouble(txt_preco.Text),
                Quantidade = Convert.ToDouble(txt_qntd.Text),
                total = Convert.ToDouble(lbl_valortotal.Text),
                Descricao = txt_descricao.Text,
            };
        }
    }
}