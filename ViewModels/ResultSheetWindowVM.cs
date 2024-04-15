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

namespace StudentRegistrationSystem.ViewModels
{
    public partial class ResultSheetWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Results> results;

        public ResultSheetWindowVM()
        {
            results = new ObservableCollection<Results>();
            using (var db = new UserDataContext())
            {
                foreach (var r in db.Results)
                    this.results.Add(r);
            }

        }
    }

}