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

namespace slv_authApp.Screens
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Password.Password == Password2.Password ||Password.Password.Length > 0 && Password2.Password.Length > 0 && Login1.Text.Length > 0)
            {

                MessageBox.Show("You have successfully registered");
                NavigationService.Navigate(new UserPage());
            }
            else
            {
                MessageBox.Show("Error");
            }
            var db = new vlad_uEntities();
            var user = new Users();
            user.login = Login1.Text;
            user.password = Password2.Password;
            db.Users.Add(user);
            db.SaveChanges();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
