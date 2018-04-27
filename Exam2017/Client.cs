using System;

namespace Exam2017
{
    internal class Client
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string City { get; private set; }


        public void SetName(string first, string last)
        {
            if (first.Length + last.Length > 30)
                throw new ArgumentException();
            Name = string.Join(" ", first, last);
        }

        public void SetCity(string city)
        {
            if (city.Length > 10)
                throw new ArgumentException();
            City = city;
        }

        public void SetCode(string code)
        {
            if (code.Length != 10)
                throw new ArgumentException();
            Code = code;
        }

        public Client()
        {
            
        }

    }
    }
