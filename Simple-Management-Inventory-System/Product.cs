using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Management_Inventory_System
{
    public class Product
    {
        private string name;
        private int quantity;
        private int price;

        public Product(string name, int quantity, int price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            set { name = value.Length > 50 ? value[..50] : value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
