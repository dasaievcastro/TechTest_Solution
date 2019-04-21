using System;
using ExpectedObjects;
using Xunit;

namespace TechtTest_Test
{
    public class EmployeeTest
    {
        private int _HoursWorked;
        private int _HourRate;
        private int _Location;

        public EmployeeTest()
        {
            _HoursWorked = 10;
            _HourRate = 40;
            _Location = 1;
        }

        [Fact]
        public void Should_have_create_an_employee()
        {
            var EmployeeTemplate = new
            {
                HoursWorked = 10,
                HourRate = 40,
                Location = (Countries)1

            };
            var EmployeeObject = BuilderEmployee.Create().WorkedFor(_HoursWorked).EarnsForHour(_HourRate).LivesIn(_Location).Build();
            //I make a simple compare just to check if the EmployeeTemplate are equal to Employee.
            EmployeeTemplate.ToExpectedObject().ShouldMatch(EmployeeObject);
        }
    }

    public class Employee
    {
        public int HoursWorked { get; set; }
        public int HourRate { get; set; }
        public Countries Location { get; set; }

        public Employee(int _hoursWorked, int _hourRate, Countries _location)
        {
            this.HoursWorked = _hoursWorked;
            this.HourRate = _hourRate;
            this.Location = _location;
        }
    }

    public enum Countries
    {
        Ireland,
        Italy,
        Germany
    }

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
