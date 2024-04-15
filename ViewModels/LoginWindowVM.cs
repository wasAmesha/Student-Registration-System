using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentRegistrationSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentRegistrationSystem.ViewModels
{
    public partial class LoginWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;


        [RelayCommand]
        public void Login()
        {
            var UserName = username;
            var Password = password;
            using (UserDataContext context = new UserDataContext())
            {

                bool userfound = context.Users.Any(user => user.UserName == UserName && user.Password == Password);
                bool admin = context.Admin.Any(user => user.UserName == UserName && user.Password == Password);
                if (admin)
                {
                    AdminAccess();

                }


                else if (userfound)
                {
                    GrantAccess();

                }
                else
                {
                    MessageBox.Show("Invaild Username or Password!");
                }
            }
        }

        public void GrantAccess()
        {
            UserHomeWindow userHome = new UserHomeWindow();
            userHome.Show();

        }
        public void AdminAccess()
        {
            AdminHomeWindow adminHome = new AdminHomeWindow();
            adminHome.Show();


        }



    }
}