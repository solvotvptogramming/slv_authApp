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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var db = new vlad_uEntities();
            var users = db.Users.Where((user) => user.login == Login.Text && user.password == Password.Password).ToList();
            if (users.Count > 0)
            {
                Console.WriteLine(db.User_Type.Find(users[0].type).Name);
                if (users[0].type == 1)
                {
                    NavigationService.Navigate(new UserPage[0]);

                }
                else if (users[0].type == 2)
                {
                    NavigationService.Navigate(new AdminPage(users[0]));
                }



            }
            else
            {
                MessageBox.Show("You are not in the list or you entered incorrect data");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
