﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    //Define a class named Coach that inherits from the base class person
    public class Coach : Person
    {
        //Define an auto-implemented property for HireDate
        public DateTime StartDate { get; set; }

        //Define a constructor that passes FullName to the Person base class

        public Coach(string fullName, DateTime startDate) : base(fullName)
        {
            StartDate = startDate;
        }

        public override string ToString()
        {
            return $"{FullName}, {StartDate}";
        }
    }
}
