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
    public partial class ResultWindowVM : ObservableObject
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
        public ObservableCollection<Results> results;

        [ObservableProperty]
        public Results selectedStudent = null;

        public double gpa;


        [RelayCommand]
        public void Create()
        {

            if (StudentId != null)
            {

                using (var db = new UserDataContext())
                {
                    bool studentfound = db.Results.Any(student => student.StudentId == StudentId);

                    if (!studentfound)
                    {
                        CalGPA();


                        Results res = new Results()
                        {
                            StudentId = studentId,
                            EE3301 = eE3301,
                            EE3302 = eE3302,
                            EE3203 = eE3203,
                            EE3305 = eE3305,
                            EE3250 = eE3250,
                            EE3151 = eE3151,
                            IS3301 = iS3301,
                            IS3302 = iS3302,
                            IS3307 = iS3307,
                            GPA=gpa,

                        };

                        db.Results.Add(res);
                        db.SaveChanges();

                        MessageBox.Show("Results Entered Successfully.","Message");

                        results.Add(res);

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
                        MessageBox.Show("Results have already Entered.", "Error");
                    }

                }

            }
            else
            {
                MessageBox.Show("Please Enter the StudentId", "Warning!");
            }
        }


        [RelayCommand]
        public void Delete()
        {
            if (selectedStudent != null)
            {

                int id = selectedStudent.StudentId;

               

                using (var db = new UserDataContext())
                {
                    db.Results.Remove(selectedStudent);
                    db.SaveChanges();

                }

                results.Remove(selectedStudent);
                MessageBox.Show($"{id} is Deleted Successfully.", "Deleted");



            }
            else
            {
                MessageBox.Show("Please Select the Student before Delete.", "Error");

            }
        }


        [RelayCommand]
        public void Read()
        {
            if (selectedStudent != null)
            {


                StudentId = selectedStudent.StudentId;
                EE3301 = selectedStudent.EE3301;
                EE3302 = selectedStudent.EE3302;
                EE3203 = selectedStudent.EE3203 ;
                EE3305 = selectedStudent.EE3305;
                EE3250 = selectedStudent.EE3250;
                EE3151 = selectedStudent.EE3151;
                IS3301 = selectedStudent.IS3301;
                IS3302 = selectedStudent.IS3302;
                IS3307 = selectedStudent.IS3307;

            }
            else
            {
                MessageBox.Show("Please Select the Student", "Warning!");
            }
        }



        [RelayCommand]
        public void Update()
        {
            if (selectedStudent != null)
            {
                int selectedStudentId = selectedStudent.StudentId;

                int index = results.IndexOf(selectedStudent);

              

                    if (StudentId != selectedStudent.StudentId)
                    {
                        selectedStudent.StudentId = StudentId;
                    }

                    if (EE3301 != selectedStudent.EE3301)
                    {
                        selectedStudent.EE3301 = EE3301;
                    }

                    if (EE3302 != selectedStudent.EE3302)
                    {
                        selectedStudent.EE3302 = EE3302;
                    }

                    if (EE3203 != selectedStudent.EE3203)
                    {
                        selectedStudent.EE3203 = EE3203;
                    }

                    if (EE3305 != selectedStudent.EE3305)
                    {
                        selectedStudent.EE3305 = EE3305;
                    }

                    if (EE3250 != selectedStudent.EE3250)
                    {
                        selectedStudent.EE3250 = EE3250;
                    }

                    if (EE3151 != selectedStudent.EE3151)
                    {
                        selectedStudent.EE3151 = EE3151;
                    }

                    if (IS3301 != selectedStudent.IS3301)
                    {
                        selectedStudent.IS3301 = IS3301;
                    }

                    if (IS3302 != selectedStudent.IS3302)
                    {
                        selectedStudent.IS3302 = IS3302;
                    }

                    if (IS3307 != selectedStudent.IS3307)
                    {
                        selectedStudent.IS3307 = IS3307;
                    }



                    using (var db = new UserDataContext())
                    {
                        bool studentfound = db.Results.Any(student => student.StudentId == selectedStudent.StudentId);
                        bool idNotChanged = (selectedStudentId == StudentId);

                        if (!studentfound || idNotChanged)
                        {

                            CalGPA();

                            selectedStudent.GPA = gpa;

                            db.Results.Update(selectedStudent);
                            db.SaveChanges();

                            MessageBox.Show($"You have Successfully Updated {selectedStudent.StudentId}.", "Message");

                            results.Insert(index, selectedStudent);
                            results.RemoveAt(index + 1);

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
                            MessageBox.Show("This StudentId already exists.", "Warning!");
                        }

                    }


             
            }
            else
            {
                MessageBox.Show("Please Select the Student", "Warning!");
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



        public void CalGPA()
        {

            double ee3301Points;
            double ee3302Points;
            double ee3203Points;
            double ee3305Points;
            double ee3250Points;
            double ee3151Points;
            double is3301Points;
            double is3302Points;
            double is3307Points;


            switch (EE3301)
            {
                case "A+":
                    ee3301Points = 4.3;
                    break;
                case "A":
                    ee3301Points = 4.0;
                    break;
                case "A-":
                    ee3301Points = 3.67;
                    break;
                case "B+":
                    ee3301Points = 3.33;
                    break;
                case "B":
                    ee3301Points = 3.0;
                    break;
                case "B-":
                    ee3301Points = 2.67;
                    break;
                case "C+":
                    ee3301Points = 2.33;
                    break;
                case "C":
                    ee3301Points = 2.0;
                    break;
                case "C-":
                    ee3301Points = 1.0;
                    break;
                case "F":
                    ee3301Points = 0.0;
                    break;
                default:
                    ee3301Points = 0.0;
                    break;
            }

            switch (EE3302)
            {
                case "A+":
                    ee3302Points = 4.3;
                    break;
                case "A":
                    ee3302Points = 4.0;
                    break;
                case "A-":
                    ee3302Points = 3.67;
                    break;
                case "B+":
                    ee3302Points = 3.33;
                    break;
                case "B":
                    ee3302Points = 3.0;
                    break;
                case "B-":
                    ee3302Points = 2.67;
                    break;
                case "C+":
                    ee3302Points = 2.33;
                    break;
                case "C":
                    ee3302Points = 2.0;
                    break;
                case "C-":
                    ee3302Points = 1.0;
                    break;
                case "F":
                    ee3302Points = 0.0;
                    break;
                default:
                    ee3302Points = 0.0;
                    break;
            }

            switch (EE3203)
            {
                case "A+":
                    ee3203Points = 4.3;
                    break;
                case "A":
                    ee3203Points = 4.0;
                    break;
                case "A-":
                    ee3203Points = 3.67;
                    break;
                case "B+":
                    ee3203Points = 3.33;
                    break;
                case "B":
                    ee3203Points = 3.0;
                    break;
                case "B-":
                    ee3203Points = 2.67;
                    break;
                case "C+":
                    ee3203Points = 2.33;
                    break;
                case "C":
                    ee3203Points = 2.0;
                    break;
                case "C-":
                    ee3203Points = 1.0;
                    break;
                case "F":
                    ee3203Points = 0.0;
                    break;
                default:
                    ee3203Points = 0.0;
                    break;
            }

            switch (EE3305)
            {
                case "A+":
                    ee3305Points = 4.3;
                    break;
                case "A":
                    ee3305Points = 4.0;
                    break;
                case "A-":
                    ee3305Points = 3.67;
                    break;
                case "B+":
                    ee3305Points = 3.33;
                    break;
                case "B":
                    ee3305Points = 3.0;
                    break;
                case "B-":
                    ee3305Points = 2.67;
                    break;
                case "C+":
                    ee3305Points = 2.33;
                    break;
                case "C":
                    ee3305Points = 2.0;
                    break;
                case "C-":
                    ee3305Points = 1.0;
                    break;
                case "F":
                    ee3305Points = 0.0;
                    break;
                default:
                    ee3305Points = 0.0;
                    break;
            }

            switch (EE3250)
            {
                case "A+":
                    ee3250Points = 4.3;
                    break;
                case "A":
                    ee3250Points = 4.0;
                    break;
                case "A-":
                    ee3250Points = 3.67;
                    break;
                case "B+":
                    ee3250Points = 3.33;
                    break;
                case "B":
                    ee3250Points = 3.0;
                    break;
                case "B-":
                    ee3250Points = 2.67;
                    break;
                case "C+":
                    ee3250Points = 2.33;
                    break;
                case "C":
                    ee3250Points = 2.0;
                    break;
                case "C-":
                    ee3250Points = 1.0;
                    break;
                case "F":
                    ee3250Points = 0.0;
                    break;
                default:
                    ee3250Points = 0.0;
                    break;
            }

            switch (EE3151)
            {
                case "A+":
                    ee3151Points = 4.3;
                    break;
                case "A":
                    ee3151Points = 4.0;
                    break;
                case "A-":
                    ee3151Points = 3.67;
                    break;
                case "B+":
                    ee3151Points = 3.33;
                    break;
                case "B":
                    ee3151Points = 3.0;
                    break;
                case "B-":
                    ee3151Points = 2.67;
                    break;
                case "C+":
                    ee3151Points = 2.33;
                    break;
                case "C":
                    ee3151Points = 2.0;
                    break;
                case "C-":
                    ee3151Points = 1.0;
                    break;
                case "F":
                    ee3151Points = 0.0;
                    break;
                default:
                    ee3151Points = 0.0;
                    break;
            }

            switch (IS3301)
            {
                case "A+":
                    is3301Points = 4.3;
                    break;
                case "A":
                    is3301Points = 4.0;
                    break;
                case "A-":
                    is3301Points = 3.67;
                    break;
                case "B+":
                    is3301Points = 3.33;
                    break;
                case "B":
                    is3301Points = 3.0;
                    break;
                case "B-":
                    is3301Points = 2.67;
                    break;
                case "C+":
                    is3301Points = 2.33;
                    break;
                case "C":
                    is3301Points = 2.0;
                    break;
                case "C-":
                    is3301Points = 1.0;
                    break;
                case "F":
                    is3301Points = 0.0;
                    break;
                default:
                    is3301Points = 0.0;
                    break;
            }

            switch (IS3302)
            {
                case "A+":
                    is3302Points = 4.3;
                    break;
                case "A":
                    is3302Points = 4.0;
                    break;
                case "A-":
                    is3302Points = 3.67;
                    break;
                case "B+":
                    is3302Points = 3.33;
                    break;
                case "B":
                    is3302Points = 3.0;
                    break;
                case "B-":
                    is3302Points = 2.67;
                    break;
                case "C+":
                    is3302Points = 2.33;
                    break;
                case "C":
                    is3302Points = 2.0;
                    break;
                case "C-":
                    is3302Points = 1.0;
                    break;
                case "F":
                    is3302Points = 0.0;
                    break;
                default:
                    is3302Points = 0.0;
                    break;
            }

            switch (IS3307)
            {
                case "A+":
                    is3307Points = 4.3;
                    break;
                case "A":
                    is3307Points = 4.0;
                    break;
                case "A-":
                    is3307Points = 3.67;
                    break;
                case "B+":
                    is3307Points = 3.33;
                    break;
                case "B":
                    is3307Points = 3.0;
                    break;
                case "B-":
                    is3307Points = 2.67;
                    break;
                case "C+":
                    is3307Points = 2.33;
                    break;
                case "C":
                    is3307Points = 2.0;
                    break;
                case "C-":
                    is3307Points = 1.0;
                    break;
                case "F":
                    is3307Points = 0.0;
                    break;
                default:
                    is3307Points = 0.0;
                    break;
            }

            using (var db = new UserDataContext())
            {

                var selectedStudent = db.Modules.FirstOrDefault(student => student.StudentId == StudentId);

                var is3301Status = selectedStudent.IS3301;
                var is3307Status = selectedStudent.IS3307;



                if (is3301Status == "NONGPA" && is3307Status == "NONGPA")
                {
                    gpa = (ee3301Points * 3 + ee3302Points * 3 + ee3203Points * 2 + ee3305Points * 3 + ee3250Points * 2 + ee3151Points * 1 + is3302Points * 3) / (3 + 3 + 2 + 3 + 2 + 1 + 3);
                }
                if (is3301Status == "NONGPA" && is3307Status == "GPA")
                {
                    gpa = (ee3301Points * 3 + ee3302Points * 3 + ee3203Points * 2 + ee3305Points * 3 + ee3250Points * 2 + ee3151Points * 1 + is3302Points * 3 + is3307Points * 3) / (3 + 3 + 2 + 3 + 2 + 1 + 3 + 3);
                }
                if (is3301Status == "GPA" && is3307Status == "NONGPA")
                {
                    gpa = (ee3301Points * 3 + ee3302Points * 3 + ee3203Points * 2 + ee3305Points * 3 + ee3250Points * 2 + ee3151Points * 1 + is3301Points * 3 + is3302Points * 3) / (3 + 3 + 2 + 3 + 2 + 1 + 3 + 3);
                }
                if (is3301Status == "GPA" && is3307Status == "GPA")
                {
                    gpa = (ee3301Points * 3 + ee3302Points * 3 + ee3203Points * 2 + ee3305Points * 3 + ee3250Points * 2 + ee3151Points * 1 + is3301Points * 3 + is3302Points * 3 + is3307Points * 3) / (3 + 3 + 2 + 3 + 2 + 1 + 3 + 3 + 3);
                }
            }

            gpa = Math.Round(gpa, 4);
        }



        public ResultWindowVM()
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


