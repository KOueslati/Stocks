using System;
using System.Collections.Generic;
using System.Text;

namespace GestionStocks
{
    public class Product
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public double price { get; set; }
        public double change { get; set; }
        public string changeDirection{ get; set; }
    }
}
