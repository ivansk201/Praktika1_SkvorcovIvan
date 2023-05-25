using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace практика2
{
    class Shop
    {
        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        private Dictionary<Product, int> products;

        public Shop ()
        {
            products = new Dictionary<Product, int>( );
        }
        public void CreateProduct (string name, decimal price, int count)
        {
            products.Add(new Product(name, price, count), count);
            balance += price * count;
        }
        public void Sell (string productName, int quantity)
        {
            Product product = FindByName(productName);
            if (product != null)
            {
                if (products.ContainsKey(product))
                {
                    if (products[product] >= quantity)
                    {
                        products[product] -= quantity;
                        balance += product.price * quantity; 
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно товара!", "Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Товар не найден!", "Ошибка");
            }
        }
        public void SaveData(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(balance);
                foreach (var entry in products)
                {
                    Product product = entry.Key;
                    int quantity = entry.Value;
                    writer.WriteLine($"{product.name},{product.price},{quantity}");
                }
            }
        }
        public decimal GetBalance()
        {
            return balance;
        }

        public List<Product> GetAllProducts()
        {
            return products.Keys.ToList();
        }
        
        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.name == name)
                {
                    return product;
                }
            }
            return null;
        }
        public List<Product> GetAllProduct ()
        {
            return new List<Product>(products.Keys);
        }
        public void LoadData(string filename)
        {
            if (File.Exists(filename))
            {
                products.Clear();

                using (StreamReader reader = new StreamReader(filename))
                {
                    decimal loadedBalance;
                    if (decimal.TryParse(reader.ReadLine(), out loadedBalance))
                    {
                        balance = loadedBalance;
                    }
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        if (data.Length == 3)
                        {
                            string name = data[0];
                            decimal price;
                            int quantity;

                            if (decimal.TryParse(data[1], out price) && int.TryParse(data[2], out quantity))
                            {
                                Product product = new Product(name, price, quantity);
                                products.Add(product, quantity);
                            }
                        }
                    }
                }
            }
        }
    }
}
