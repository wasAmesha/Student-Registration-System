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
    public partial class StudentResultWindowVM : ObservableObject
    {
        
        [ObservableProperty]
        public int studentId;

        [ObservableProperty]
        public string eE3301;

        [ObservableProperty]
        public string eE3302;

        [ObservableProperty]
        public string eE3203;

        [ObservableProperty]
        public string eE3305;

        [ObservableProperty]
        public string eE3250;

        [ObservableProperty]
        public string eE3151;

        [ObservableProperty]
        public string iS3301;

        [ObservableProperty]
        public string iS3302;

        [ObservableProperty]
        public string iS3307;

        [ObservableProperty]
        public double gpa;



        [RelayCommand]
        public void ViewSheet()
        {
            ResultSheetWindow sheet = new ResultSheetWindow();
            sheet.Show();

        }



        [RelayCommand]
        public void Search()
        {

            if (StudentId != null)
            {

                using (var db = new UserDataContext())
                {
                    bool studentfound = db.Results.Any(student => student.StudentId == StudentId);


                    if (studentfound)
                    {
                        var selectedStudent = db.Results.FirstOrDefault(student => student.StudentId == StudentId);

                        EE3301 = selectedStudent.EE3301;
                        EE3302 = selectedStudent.EE3302;
                        EE3203 = selectedStudent.EE3203;
                        EE3305 = selectedStudent.EE3305;
                        EE3250 = selectedStudent.EE3250;
                        EE3151 = selectedStudent.EE3151;
                        IS3301 = selectedStudent.IS3301;
                        IS3302 = selectedStudent.IS3302;
                        IS3307 = selectedStudent.IS3307;
                        Gpa = selectedStudent.GPA;
                        
                    }
                    else
                    {
                        MessageBox.Show("Incorrect StudentId", "Error");
                    }


                }

                

            }
            else
            {
                MessageBox.Show("Please Enter the StudentId", "Warning!");
            }
        }
       

    }


}