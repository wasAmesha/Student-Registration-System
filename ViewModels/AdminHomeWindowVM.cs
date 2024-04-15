using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentRegistrationSystem.Views;
using System.Windows;


namespace StudentRegistrationSystem.ViewModels
{
    public partial class AdminHomeWindowVM : ObservableObject
    {

        [RelayCommand]
        public void CreateUser()
        {
            CreateUserWindow create = new CreateUserWindow();
            create.Show();
        }

        [RelayCommand]
        public void AddResult()
        {
            ResultWindow result = new ResultWindow();
            result.Show();
        }

        [RelayCommand]
        public void ViewResult()
        {
            ResultSheetWindow sheet = new ResultSheetWindow();
            sheet.Show();
        }

    }


}