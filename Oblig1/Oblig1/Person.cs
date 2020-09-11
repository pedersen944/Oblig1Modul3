using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int BirthYear;
        public int DeathYear;
        public Person Father;
        public Person Mother;

        public string GetDescription()
        {
            string detect = null;
            if (FirstName != null) detect += $"{FirstName} ";
            if (LastName != null) detect += $"{LastName} ";
            if (Id != 0) detect += $"(Id={Id}) ";
            if (BirthYear != 0) detect += $"Født: {BirthYear} ";
            if (DeathYear != 0) detect += $"Død: {DeathYear} ";
            if (Father != null) detect += $"Far: {Father.FirstName} " + $"(Id={Father.Id})";
            if (Mother != null) detect += $" Mor: {Mother.FirstName} " + $"(Id={Mother.Id})";

            return detect;
        }
    }
}
