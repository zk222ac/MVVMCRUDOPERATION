using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCRUDOperation.Model
{
    public class Singleton
    {
        // create object instance of your business logic 
        public static Student Student;

        // step 1 : declare the object instance of class Singleton 
        private static Singleton Instance { get; set; }

        private Singleton()
        {
            // create an object instance of your business class
            Student = new Student();
        }

        // step 2:  this instance property check first if instance is not null ,
        // if its null then create an object instance otherwise return current instance 

        public static Singleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Singleton();
            }
            return Instance;
        }
        // Create method based upon your business logic 

        public void SetStudent(Student student)
        {
            Student = student;
        }
        public string GetName()
        {
            return Student.Name;
        }
        public string GetCpr()
        {
            return Student.Cpr;
        }
        public string GetCountry()
        {
            return Student.Country;
        }
        public string GetCity()
        {
            return Student.City;
        }
        public string GetDob()
        {
            return Student.Dob;
        }
        public string GetZipCode()
        {
            return Student.ZipCode;
        }
        public string GetImageUrl()
        {
            return Student.ImageUrl;
        }
    }
}
