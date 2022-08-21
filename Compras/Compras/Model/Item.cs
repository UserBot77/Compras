using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Compras.Models
{
    internal class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Produto { get; set; }
        public double Quantidade { get; set; }
        public double? PreçoUnitário { get; set; }
        public string Descrição { get; set; }
        public double? Total { get => Quantidade * PreçoUnitário; }
    }
}