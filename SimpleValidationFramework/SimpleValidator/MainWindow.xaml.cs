using SimpleValidationLibrary.Util;
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
        Model.User usermodel;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.usermodel = new Model.User();
            usermodel.Address = new Model.Address();
            this.RegisterForm.DataContext = usermodel;
            BindingErrorMessage();
        }
        

        private void button2_Click(object sender, RoutedEventArgs e)

        {

            Reset();

        }

        public void Reset()

        {
            FirstName.Text = "";
            LastName.Text = "";
            Email.Text = "";
            Age.Text = "";
            Password.Password = "";
        }

        private void button3_Click(object sender, RoutedEventArgs e)

        {

            Close();

        }

        private void Submit_Click(object sender, RoutedEventArgs e)

        {

            if (usermodel.IsValid)
                MessageBox.Show("This user infomation is valid", "register Successfully");
            else MessageBox.Show("This user infomation is invalid", "register Failed");

        }

        private void BindingErrorMessage()
        {
            List<TextBlockErrorBindingCarrier> list = new List<TextBlockErrorBindingCarrier>();
            list.Add(new TextBlockErrorBindingCarrier(errorFirstName, "FirstName"));
            list.Add(new TextBlockErrorBindingCarrier(errorLastName, "LastName"));
            list.Add(new TextBlockErrorBindingCarrier(errorEmail, "Email"));
            list.Add(new TextBlockErrorBindingCarrier(errorPassword, "Password"));
            list.Add(new TextBlockErrorBindingCarrier(errorAge, "Age"));
            foreach (var e in list)
            { 
                this.usermodel.Attach(e);
            }
        }
    }
}
