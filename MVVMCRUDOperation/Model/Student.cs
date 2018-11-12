using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCRUDOperation.Model
{
    // Business Logic Prototype
   public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Dob { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Cpr { get; set; }
        public string ImageUrl { get; set; }

        public Student(int id, string name, string country, string dob, string city, string zipCode, string cpr, string imageUrl)
        {
            Id = id;
            Name = name;
            Country = country;
            Dob = dob;
            City = city;
            ZipCode = zipCode;
            Cpr = cpr;
            ImageUrl = imageUrl;
        }
        public Student()
        {
            // set default values if user not provide it on runtime 
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
