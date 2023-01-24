using System;
using System.Collections.Generic;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] mass = new string[5] 
        { 
            "Ivan", 
            "Fedor", 
            "Victor", 
            "Georgiy", 
            "Vasiliy" 
        };
        public MainWindow()
        {
            InitializeComponent();
            ListUsersRefresh();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list1.SelectedItem != null)
            {
                User foundedUser = GetUserFromLocal(list1.SelectedItem.ToString());
                txtName.Text = foundedUser.Name;
                txtAge.Text = foundedUser.Age;
                txtEmail.Text = foundedUser.EMail;
                txtVac.Text = foundedUser.Vacancy;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User.AddUserToDataBase(new User(txtName.Text, txtAge.Text, 
                txtEmail.Text, txtVac.Text));
            ListUsersRefresh();
            txtName.Clear();
            txtAge.Clear();
            txtEmail.Clear();
            txtVac.Clear();
        }


        private void ListUsersRefresh()
        {
            list1.Items.Clear();
            foreach (var item in User.GetUsersListFromDB())
            {
                list1.Items.Add(item.Name);
            }
        }

        private User GetUserFromLocal(string name)
        {
            var list = User.GetUsersListFromDB();
            return list.Find(x => x.Name == name);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //User.EditUser();
        }
    }
}
