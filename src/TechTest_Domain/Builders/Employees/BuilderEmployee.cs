using System;
using TechTest_Domain.Classes.Employees;
using TechTest_Domain.ENums.Countries;

namespace TechTest_Domain.Builders.Employees
{
    public class BuilderEmployee
    {
        private int HoursWorked;
        private int HourRate;
        private Countries Location;

        public static BuilderEmployee Create()
        {
            return new BuilderEmployee();
        }

        public BuilderEmployee WorkedFor(int _hoursWorked)
        {
            HoursWorked = _hoursWorked;
            return this;
        }

        public BuilderEmployee EarnsForHour(int _hoursRate)
        {
            HourRate = _hoursRate;
            return this;
        }

        public BuilderEmployee LivesIn(int _location)
        {
            Location = (Countries)_location;
            return this;
        }

        public Employee Build()
        {
            return new Employee(this.HoursWorked, this.HourRate, this.Location);
        }

    }
}
