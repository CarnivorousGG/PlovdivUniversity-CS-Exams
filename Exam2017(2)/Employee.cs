using System;

namespace Exam2017_2_
{
    public class Employee
    {
        public string Name { get; private set; }
        public string EGN { get; private set; }
        public string LatinName { get; private set; }
        public string Country { get; private set; }
        public string Postal { get; private set; }
        public string City { get; private set; }

       public void SetPostal(string postal)
        {
            if (postal.Length > 30)
            {
                throw new ArgumentException();
            }
            Postal = postal;
        }

        public void SetCity(string city)
        {
            if (city.Length > 30)
            {
                throw new ArgumentException();
            }
            City = city;
        }

        public Employee(string name, string egn, string latinName, string country)
        {
            if (name.Length > 50)
            {
                throw new ArgumentException();
            }
            Name = name;

            if (egn.Length > 15)
            {
                throw new ArgumentException();
            }
            EGN = egn;

            if (latinName.Length > 50)
            {
                throw new ArgumentException();
            }
            LatinName = latinName;

            if (country.Length > 30)
            {
                throw new ArgumentException();
            }
            Country = country;
        }
       
    }
}