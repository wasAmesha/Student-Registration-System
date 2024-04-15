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
    public partial class UserHomeWindowVM : ObservableObject
    {

        [RelayCommand]
        public void Register()
        {
            StudentInformationWindow info = new StudentInformationWindow();
            info.Show();
        }

        [RelayCommand]
        public void ModuleRegister()
        {
            ModuleRegistrationWindow moduleReg = new ModuleRegistrationWindow();
            moduleReg.Show();
        }

        [RelayCommand]
        public void Result()
        {
            StudentResultWindow res = new StudentResultWindow();
            res.Show();
        }


    }

    
}
