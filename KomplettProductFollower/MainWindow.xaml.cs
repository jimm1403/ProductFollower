using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KomplettProductFollower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product newProduct;
        List<Product> productList = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void run_cmd()
        {
            
            string fileName = @"C:\Users\jimmi\source\repos\KomplettProductFollower\KomplettProductFollower\benqPriceCheck.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Users\jimmi\AppData\Local\Programs\Python\Python36-32\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            List<string> products = output.Split('#').ToList();
            products.RemoveAt(products.Count -1);
            foreach (var product in products)
            {
                string[] tempArray = product.Split(':');
                newProduct = new Product(tempArray[0], tempArray[1]);
                productList.Add(newProduct);
            }

            p.WaitForExit();

        }

        private void getPriceBtn_Click(object sender, RoutedEventArgs e)
        {
            productList.Clear();
            productListBox.Items.Clear();
            run_cmd();
            foreach (Product product in productList)
            {
                productListBox.Items.Add(product.Name + " - " + product.Price);
            }
            
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addProductTextBox.Text != "")
            {
                using (var writer = File.AppendText(@"C:\Users\jimmi\source\repos\KomplettProductFollower\KomplettProductFollower\ProductFollow.txt"))
                {
                    writer.Write(addProductTextBox.Text);
                }
                addProductTextBox.Clear();
            }

            //StreamWriter sw = new StreamWriter(@"C:\Users\jimmi\source\repos\KomplettProductFollower\KomplettProductFollower\ProductFollow.txt");
                //sw.Write(addProductTextBox.Text);
                //sw.Flush();
                
            else
            {
                MessageBox.Show("Remember to paste a URL to the textbox.");
            }
        }

    }
}
