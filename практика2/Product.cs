using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика2
{
    class Product
    {
        public decimal price { get; set; }
        public string name { get; set; }
        public int count { get; set; }

        public Product (string Name, decimal Price, int Count)
        {
            this.name = Name;
            this.price = Price;
            this.count = Count;
        }

        public string GetInfo ()
        {
            return $"Наименование: {name}; Цена: {price} руб.; Кол-во товара {count} шт.";
        }
    }
}
