using System;
using ExpectedObjects;
using Xunit;

namespace TechtTest_Test
{
    public class EmployeeTest
    {
        public EmployeeTest()
        {

        }

        [Fact]
        public void Should_have_create_a_employee()
        {
            var EmployeeTemplate = new
            {
                HoursWorked = 10,
                HourRate = 40,
                Location = 1

            };
            var EmployeeObject = new Employee(10, 40, 1);
            //I make a simple compare just to check if the EmployeeTemplate are equal to Employee.
            EmployeeTemplate.ToExpectedObject().ShouldMatch(EmployeeObject);
        }
    }
}
