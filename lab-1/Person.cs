using System;

namespace lab_1
{
    public class Person
    {
        private string firstName;

        private Person(string firstName)
        {
            FirstName = firstName;
        }

        public static Person OfName(string name)
        {
            if (name != null && name.Length >= 2)
            {
                return new Person(name);
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value != null && value.Length >= 2)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Nieprawidłowe imie.");
                }
            }
        }
    }
}
