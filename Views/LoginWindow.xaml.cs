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
using System.Windows.Shapes;
using StudentRegistrationSystem.ViewModels;

namespace StudentRegistrationSystem.Views
{
   
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Username = UserName.Text;
            var Password = PasswordText.Password;

            using (UserDataContext context = new UserDataContext())
            {
                bool userfound = context.Users.Any(user => user.UserName == Username && user.Password == Password);
                bool admin = context.Admin.Any(user => user.UserName == Username && user.Password == Password);
                if (admin)
                {
                    AdminAccess();  
                    Close();

                }


                else if (userfound)
                {
                    GrantAccess();
                    Close();
                }
                else
                {
                    MessageBox.Show("Invaild Username or Password!");
                }

            }

        }


        public void GrantAccess()
        {
            UserHomeWindow user = new UserHomeWindow();
            user.Show();

        }
        public void AdminAccess()
        {
            AdminHomeWindow admin = new AdminHomeWindow();
            admin.Show();


        }


    }
}

