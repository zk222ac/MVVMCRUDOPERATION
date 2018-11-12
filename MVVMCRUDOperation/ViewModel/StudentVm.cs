using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMCRUDOperation.Model;
using MVVMCRUDOperation.View;

namespace MVVMCRUDOperation.ViewModel
{
    class StudentVm : NotifyPropertyChangeClass
    {
        // Step 1 : View ListView Item Source attribute connect this property which we also called source property (ListStudents)
       
        public ObservableCollection<Student> ListStudents { get; set; }

        // Step 3: Selected Item source instance field
        private Student _selectedItemStudent;

        // Step 4 : Add new Student
        public Student AddStudent { get; set; }

        // Step 3a: Selected Item source property , On per student item selection change index
        // we need to call PropertyChange interface because we change model properties in every selection
        public Student SelectedItemStudent
        {
            get => _selectedItemStudent;
            set
            {
                _selectedItemStudent = value;
                OnPropertyChanged(nameof(SelectedItemStudent));
            }
        }
        // Step 3b: Create different Source Commands which is exposed delegate methods 
        public RelayCommand AddStudentCommand { get; set; }
        public RelayCommand UpdateStudentCommand { get; set; }
        public RelayCommand DeleteStudentCommand { get; set; }
        public RelayCommand RefreshStudentCommand { get; set; }
        public RelayCommand GoPage1Command { get; set; }
       

        //  Frame Navigation property
        public readonly FrameNavigate FrameNavigate;
        // User singleton property 
        public readonly Singleton UserSingleton;
        public StudentVm()
        {
            // Step 2: Add some by default values 
            ListStudents = new ObservableCollection<Student>()
            {
                new Student(1, "liza" , "Australia", "2001", "Melbourne", "4220", "354648-4657" ,"../Assets/eliza.JPG" ),
                new Student(2, "daniel" ,"UK", "2004", "London", "4567", "354648-5637" ,"../Assets/daniel.JPG" ),
                new Student(3, "benny" , "USA", "2001", "New York", "5673", "354648-4567" ,"../Assets/benny.JPG" ),
                new Student(4, "ann" , "Denmark", "2000", "Copenhagen", "5992", "354648-4657" ,"../Assets/ann.JPG" ),
                new Student(5, "carol" , "China", "2000", "Beijing", "5992", "354648-4657" ,"../Assets/carol.JPG" )
            };

            // initialize the selectedItemStudent property in constructor
            SelectedItemStudent = new Student();
            AddStudent = new Student();
            
            // Relay Command 
            AddStudentCommand = new RelayCommand(DoAddStudent);
            UpdateStudentCommand = new RelayCommand(DoUpdateStudent);
            DeleteStudentCommand = new RelayCommand(DoDeleteStudent);
            RefreshStudentCommand = new RelayCommand(DoRefreshStudent);
            GoPage1Command = new RelayCommand(DoGoPage1);
           

            // Frame navigation Object initialization 
            FrameNavigate = new FrameNavigate();

            //  User singleton Instance
            UserSingleton = Singleton.GetInstance();
        }

        public void DoAddStudent()
        {
            // add the name of image in URL path
            string img = "../Assets/" + AddStudent.ImageUrl + ".jpg";
            AddStudent.ImageUrl = img;
            ListStudents.Add(AddStudent);
        }
        public void DoUpdateStudent()
        {
            ListStudents = new ObservableCollection<Student>()
            {
                new Student(SelectedItemStudent.Id, SelectedItemStudent.Name,SelectedItemStudent.Country,SelectedItemStudent.Dob,SelectedItemStudent.City,SelectedItemStudent.ZipCode,SelectedItemStudent.Cpr,SelectedItemStudent.ImageUrl)
            };
        }
        public void DoDeleteStudent()
        {
            ListStudents.Remove(SelectedItemStudent);
        }
        public void DoRefreshStudent()
        {
            // Refresh List Again
            ListStudents = new ObservableCollection<Student>()
            {
                new Student(1, "liza" , "Australia", "2001", "Melbourne", "4220", "354648-4657" ,"../Assets/eliza.JPG" ),
                new Student(2, "daniel" ,"UK", "2004", "London", "4567", "354648-5637" ,"../Assets/daniel.JPG" ),
                new Student(3, "benny" , "USA", "2001", "New York", "5673", "354648-4567" ,"../Assets/benny.JPG" ),
                new Student(4, "ann" , "Denmark", "2000", "Copenhagen", "5992", "354648-4657" ,"../Assets/ann.JPG" ),
                new Student(5, "carol" , "China", "2000", "Beijing", "5992", "354648-4657" ,"../Assets/carol.JPG" )
            };
            // Here I am using Property change Interface because it is changes the model property here
            OnPropertyChanged(nameof(ListStudents));
        }
        public void DoGoPage1()
        {
            // save complete student object instance in singleton SetStudent method
            UserSingleton.SetStudent(SelectedItemStudent);

            // Redirect MainPage to Page1
            Type type = typeof(Page1);
            FrameNavigate.ActivateFrameNavigation(type);
        }
       
    }
}
