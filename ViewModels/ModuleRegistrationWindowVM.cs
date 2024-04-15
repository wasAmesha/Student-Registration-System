using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentRegistrationSystem.Views;
using StudentRegistrationSystem.Tables;
using System.Windows;


namespace StudentRegistrationSystem.ViewModels
{
    public partial class ModuleRegistrationWindowVM : ObservableObject
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


        [RelayCommand]
        public void Submit()
        {

            if (StudentId != null) 
            {

                using (var db = new UserDataContext())
                {
                    bool studentfound = db.Modules.Any(student => student.StudentId == StudentId);

                    if (!studentfound)
                    {
                        Modules sd = new Modules()
                        {
                            StudentId = studentId,
                            EE3301=eE3301,
                            EE3302=eE3302,
                            EE3203=eE3203,
                            EE3305=eE3305,
                            EE3250=eE3250,
                            EE3151=eE3151,
                            IS3301= iS3301,
                            IS3302= iS3302,
                            IS3307= iS3307,

                        };

                        db. Modules.Add(sd);
                        db.SaveChanges();

                        MessageBox.Show("You have Registered for the Modules Successfully.","Message");

                        StudentId = 0;
                        EE3301 = null;
                        EE3302 = null;
                        EE3203 = null;
                        EE3305 = null;
                        EE3250 = null;
                        EE3151 = null;
                        IS3301 = null;
                        IS3302 = null;
                        IS3307 = null;


                    }
                    else
                    {
                        MessageBox.Show("This Student has already registered.", "Message");
                    }

                }

              

            }
            else
            {
                MessageBox.Show("Should enter the StudentId", "Warning!"); 
            }
        }



        [RelayCommand]
        public void Search()
        {
            
            if (StudentId != null)
            {

                using (var db = new UserDataContext())
                {
                    bool studentfound = db.Modules.Any(student => student.StudentId == StudentId);


                    if (studentfound)
                    {
                        var selectedStudent = db.Modules.FirstOrDefault(student => student.StudentId == StudentId);

                        EE3301 = selectedStudent.EE3301;
                        EE3302 = selectedStudent.EE3302;
                        EE3203 = selectedStudent.EE3203;
                        EE3305 = selectedStudent.EE3305;
                        EE3250 = selectedStudent.EE3250;
                        EE3151 = selectedStudent.EE3151;
                        IS3301 = selectedStudent.IS3301;
                        IS3302 = selectedStudent.IS3302;
                        IS3307 = selectedStudent.IS3307;
                    }
                    else
                    {
                        MessageBox.Show("You have not registered for the modules!", "Warning!");
                    }
                

                 

                }

              

            }
            else
            {
                MessageBox.Show("Please Enter the StudentId", "Warning!");
            }
        }

        [RelayCommand]

        public void Clear()
        {
            StudentId = 0; 
            EE3301 = null;
            EE3302 = null;
            EE3203 = null;
            EE3305 = null;
            EE3250 = null;
            EE3151 = null;
            IS3301 = null;
            IS3302 = null;
            IS3307 = null;

        }
    }
}
