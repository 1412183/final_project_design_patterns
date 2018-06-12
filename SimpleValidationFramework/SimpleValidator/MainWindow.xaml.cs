using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SimpleValidator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        

        private void button2_Click(object sender, RoutedEventArgs e)

        {

            Reset();

        }

        public void Reset()

        {

            textBoxFirstName.Text = "";

            textBoxLastName.Text = "";

            textBoxEmail.Text = "";

            textBoxAddress.Text = "";

            passwordBox1.Password = "";

            passwordBoxConfirm.Password = "";

        }

        private void button3_Click(object sender, RoutedEventArgs e)

        {

            Close();

        }

        private void Submit_Click(object sender, RoutedEventArgs e)

        {

           

        }
    }
}
