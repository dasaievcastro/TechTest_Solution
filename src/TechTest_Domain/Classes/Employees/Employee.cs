using System;
using TechTest_Domain.ENums.Countries;

namespace TechTest_Domain.Classes.Employees
{
    public class Employee
    {
        public int HoursWorked { get; set; }
        public double HourRate { get; set; }
        public Countries Location { get; set; }

        public Employee(int _hoursWorked, double _hourRate, Countries _location)
        {
            this.HoursWorked = _hoursWorked;
            this.HourRate = _hourRate;
            this.Location = _location;
        }
    }
}
