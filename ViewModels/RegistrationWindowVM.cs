using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentRegistrationSystem.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentRegistrationSystem.ViewModels
{
    public partial class RegistrationWindowVM : ObservableObject
    {


        [ObservableProperty]
        public int studentId;

        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public string dateOfbirth;

        [ObservableProperty]
        public string address;

        [ObservableProperty]
        public string contactNo;

        [ObservableProperty]
        public string email;

     

        [RelayCommand]
        public void Create()
        {
            
            if (StudentId != null) 
            {

                using (var db = new UserDataContext())
                {
                    bool studentfound = db.StudentDetails.Any(student => student.StudentId == StudentId);

                    if (!studentfound)
                    {
                        StudentDetails sd = new StudentDetails()
                        {
                            StudentId = studentId,
                            FirstName = firstName,
                            LastName = lastName,
                            DOB = dateOfbirth,
                            Address = address,
                            ContactNo = contactNo,
                            Email = email,

                        };

                        db.StudentDetails.Add(sd);
                        db.SaveChanges();

                        MessageBox.Show("Registered Successfully.","Message");

                       

                        StudentId = 0; 
                        FirstName = null;
                        LastName = null;
                        DateOfbirth = null;
                        Address = null;
                        ContactNo = null;
                        Email = null;

                    }
                    else
                    {
                        MessageBox.Show("This StudentId has already registered.", "Error");
                    }

                }

            }
            else
            {
                MessageBox.Show("Please Enter the StudentId", "Warning!");
            }
        }



        [RelayCommand]
        public void Search()
        {
            if (StudentId != null)
            {

                using (var db = new UserDataContext())
                {
                    bool studentfound = db.StudentDetails.Any(student => student.StudentId == StudentId);


                    if (studentfound)
                    {
                        var selectedStudent = db.StudentDetails.FirstOrDefault(student => student.StudentId == StudentId);

                        StudentId = selectedStudent.StudentId;
                        FirstName = selectedStudent.FirstName;
                        LastName = selectedStudent.LastName;
                        DateOfbirth = selectedStudent.DOB;
                        Address = selectedStudent.Address;
                        ContactNo = selectedStudent.ContactNo;
                        Email = selectedStudent.Email;
                    }
                    else
                    {
                        MessageBox.Show("You have not Registered!", "Warning!");
                    }


                }


            }
            else
            {
                MessageBox.Show("Please Enter Your StudentId", "Warning!");
            }
        }

    


        [RelayCommand]
        public void Update()
        {
            using (var db = new UserDataContext())
            {

                if (StudentId != null)
                {
                    var selectedStudent = db.StudentDetails.FirstOrDefault(student => student.StudentId == StudentId);

                    int selectedStudentId = selectedStudent.StudentId;

                    if (StudentId != selectedStudent.StudentId)
                    {
                        selectedStudent.StudentId = StudentId;
                    }

                    if (FirstName != selectedStudent.FirstName)
                    {
                        selectedStudent.FirstName = FirstName;
                    }

                    if (LastName != selectedStudent.LastName)
                    {
                        selectedStudent.LastName = LastName;
                    }

                    if (DateOfbirth != selectedStudent.DOB)
                    {
                        selectedStudent.DOB = DateOfbirth;
                    }

                    if (Address != selectedStudent.Address)
                    {
                        selectedStudent.Address = Address;
                    }

                    if (ContactNo != selectedStudent.ContactNo)
                    {
                        selectedStudent.ContactNo = ContactNo;
                    }

                    if (Email != selectedStudent.Email)
                    {
                        selectedStudent.Email = Email;
                    }



                    bool studentfound = db.StudentDetails.Any(student => student.StudentId == selectedStudent.StudentId);
                    bool idNotChanged = (selectedStudentId == StudentId);

                    if (!studentfound || idNotChanged)
                    {
                        db.StudentDetails.Update(selectedStudent);
                        db.SaveChanges();

                        MessageBox.Show("You have successfully Updated.", "Message");
                       
                        StudentId = 0;
                        FirstName = null;
                        LastName = null;
                        DateOfbirth = null;
                        Address = null;
                        ContactNo = null;
                        Email = null;

                    }
                    else
                    {
                        MessageBox.Show("This StudentId has already registered.", "Warning!");
                    }

                    


                }
                else
                {
                    MessageBox.Show("Please Search the StudentId before Update!", "Warning!");
                }


              
            }
        }

        [RelayCommand]
        public void Delete()
        {
           
            using (var db = new UserDataContext())
            {
                if (StudentId != null)
                {
                    var selectedStudent = db.StudentDetails.FirstOrDefault(student => student.StudentId == StudentId);

                    string name = selectedStudent.FirstName;

                        db.StudentDetails.Remove(selectedStudent);
                        db.SaveChanges();

                  
                    MessageBox.Show($"{name} is Deleted Successfully.", "Deleted");

                    StudentId = 0;
                    FirstName = null;
                    LastName = null;
                    DateOfbirth = null;
                    Address = null;
                    ContactNo = null;
                    Email = null;

                }
                else
                {
                    MessageBox.Show("Please Search the StudentId before Delete.", "Error");

                }

              
            }
        }

        [RelayCommand]

        public void Clear()
        {
            StudentId = 0;
            FirstName = null;
            LastName = null;
            DateOfbirth = null;
            Address = null;
            ContactNo = null;
            Email = null;
        }

      

    }

}

