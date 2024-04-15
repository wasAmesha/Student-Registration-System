﻿using System;
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
   
    public partial class ResultSheetWindow : Window
    {
        public ResultSheetWindow()
        {
            InitializeComponent();
            DataContext = new ResultSheetWindowVM();
        }
    }
}