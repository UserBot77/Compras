using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Compras.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Produto { get; set; }
        public double? PrecoUnitario { get; set; }
        public double Quantidade { get; set; }
        public string Descricao { get; set; }
        public double? Total { get => Quantidade * PrecoUnitario; }
    }
}