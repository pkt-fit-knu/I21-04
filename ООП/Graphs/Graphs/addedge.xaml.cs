using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Graphs
{

    /// <summary>
    /// Логика взаимодействия для addedge.xaml
    /// </summary>
    public partial class addedge : Window
    {
        public int w;
        
        public addedge()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            int.TryParse(textBox1.Text, out w);
            if (w <= 0)
            {
                MessageBox.Show("Введіть вагу > 0");
            }
            else
            {
                this.DialogResult = true;
            }
        }
    }
}
