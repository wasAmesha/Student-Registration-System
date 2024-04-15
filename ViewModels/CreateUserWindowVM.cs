using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentRegistrationSystem.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StudentRegistrationSystem.Views;

namespace StudentRegistrationSystem.ViewModels
{
    public partial class CreateUserWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public string confirmPassword;

        [RelayCommand]
        public void Create()
        {
            

            using (var db = new UserDataContext())
            {
               

                bool passwordCorrect = (Password == ConfirmPassword);
                bool usernamefound = db.Users.Any(user => user.UserName == UserName);


                if (Password == null && ConfirmPassword == null && UserName == null)
                {
                    MessageBox.Show("Enter the data to add a new user");
                }
                else if (Password != null && ConfirmPassword != null && UserName == null)
                {
                    MessageBox.Show("User Name is Needed!");
                }
                else if (Password == null && ConfirmPassword == null && UserName != null)
                {
                    MessageBox.Show("Password is Needed!");
                }
                else if (Password != null && ConfirmPassword != null && UserName != null)
                {
                    if (passwordCorrect)
                    {
                        if (usernamefound)
                        {
                            MessageBox.Show("This username has already taken");

                            
                        }
                        else
                        {
                            User newuser = new User()
                            {
                                UserName = userName,
                                Password = password

                            };
                           
                            db.Users.Add(newuser);
                            db.SaveChanges();


                            MessageBox.Show("You have successfully create the account");

                            UserName = null;
                            Password = null;
                            ConfirmPassword = null;
                        }
                    }
                }
                else if (!passwordCorrect && UserName != null)
                {
                    MessageBox.Show("Password is not correct!");

                }

            }
        }

        [RelayCommand]
        public void Back()
        {
          

            AdminHomeWindow admin = new AdminHomeWindow();
            admin.Show();
        }

        
    }


}