using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace практика2
{
    public partial class Form1 :Form
    {
        private string filename = "shopdata.txt";
        private Shop shop;
        private decimal balance;
        public Form1 ()
        {
            InitializeComponent( );
            shop = new Shop();
            LoadData();
            UpdateProductList();
        }

        private void button2_Click (object sender, EventArgs e)
        {
            panel1.Visible = false;
            listBox1.Visible = true;
            button3.Visible = true;
            UpdateProductList( );
            listBox1.Items.Clear( );
            foreach ( var product in shop.GetAllProduct( ) )
            {
                listBox1.Items.Add(product.GetInfo( ));
            }
        }

        private void button3_Click (object sender, EventArgs e)
        {
            panel1.Visible = true;
            listBox1.Visible = false;
            button3.Visible = false;
            UpdateProductList( );
        }

        private void button1_Click (object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string price = textBox2.Text;
                string count = textBox3.Text;

                if ( string.IsNullOrWhiteSpace(name) )
                {
                    MessageBox.Show("Вы не заполнили поле \"Имя\"", "Ошибка");
                    return;
                }
                if ( string.IsNullOrWhiteSpace(price) )
                {
                    MessageBox.Show("Вы не заполнили поле \"Цена\"", "Ошибка");
                    return;
                }
                if ( string.IsNullOrWhiteSpace(count) )
                {
                    MessageBox.Show("Вы не заполнили поле \"Кол-во товара\"", "Ошибка");
                    return;
                }
                decimal price1 = decimal.Parse(price);
                int count1 = int.Parse(count);
                shop.CreateProduct(name, price1, count1);
                UpdateProductList( );
                MessageBox.Show($"Вы успешно добавили товар {name}", "Успешно");



            }
            catch { MessageBox.Show("Неизвестная ошибка", "Ошибка"); }
            
        }
        private void UpdateProductList ()
        {
            listBox1.Items.Clear();

            decimal balance = shop.GetBalance();
            label7.Text = $"Баланс: {balance} руб.";
            label8.Text = $"Баланс: {balance} руб.";
            List<Product> products = shop.GetAllProducts();
            foreach (var product in products)
            {
                listBox1.Items.Add(product.GetInfo());
            }
        }

        private void button4_Click (object sender, EventArgs e)
        {
            string name = textBox5.Text;
            int quantity = 0;

            if (!string.IsNullOrWhiteSpace(textBox4.Text) && int.TryParse(textBox4.Text, out quantity))
            {
                Product product = shop.FindByName(name);
                if (product != null)
                {
                    decimal totalPrice = product.price * quantity;

                    textBox6.Text = totalPrice.ToString();

                    shop.Sell(name, quantity);
                    UpdateProductList();
                    MessageBox.Show($"Вы успешно купили товар {name} на сумму {totalPrice} руб.", "Успех!");

                    balance += totalPrice; 
                    label7.Text = $"Баланс: {balance} руб.";
                    label8.Text = $"Баланс: {balance} руб.";
                    return;
                }
            }

            MessageBox.Show("Неверный ввод или продукт не найден!", "Ошибка");
        }
        private void SaveData()
        {
            shop.SaveData(filename);
        }

        private void LoadData()
        {
            shop.LoadData(filename);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }
    }
}
