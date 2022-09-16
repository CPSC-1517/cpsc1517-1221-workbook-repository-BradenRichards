using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    public class Person
    {
        //Define a fully implemented property for
        //Full Name with a private set

        private string _fullName = string.Empty; //Define a backing field for the FullName Property

        public string FullName
        {
            get { return _fullName; }
            private set 
            {
                //Validate new value is not null or empty string
                //or whitespaces only
                //Validate new value contains minimum
                //3 or more characters
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("FullName value is required");
                }

                //Validate new value contains minimum 3 or more characters
                if(value.Trim().Length < 3)
                {
                    throw new ArgumentException("FullName must contain 3 or more characters");
                }
                _fullName = value.Trim(); //.Trim() removes leading and trailing whitespaces 
            }
        }

        //Create a greedy constructor with a parameer for the fullName
        public Person(string _fullName)
        {
            FullName = _fullName;
        }
    }
}
