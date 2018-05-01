using System;

namespace Exam2017
{
    internal class Client
    {
        private string _name { get;  set; }
        private string _code { get;  set; }
        private string _city { get;  set; }


        public void SetName(string first, string last)
        {
            if (first.Length + last.Length > 30)
                throw new ArgumentException();
            _name = string.Join(" ", first, last);
        }

        public void SetCity(string city)
        {
            if (city.Length > 10)
                throw new ArgumentException();
            _city = city;
        }

        public void SetCode(string code)
        {
            if (code.Length != 10)
                throw new ArgumentException();
            _code = code;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetCode()
        {
            return _code;
        }

        public string GetCity()
        {
            return _city;
        }

    }
    }
