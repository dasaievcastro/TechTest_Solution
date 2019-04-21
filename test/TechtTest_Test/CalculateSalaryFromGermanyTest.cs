using System;
using TechTest_Domain.Builders.Employees;
using Xunit;

namespace TechtTest_Test
{
    public class CalculateSalaryFromGermanyTest
    {
        public CalculateSalaryFromGermanyTest()
        {
        }

        [Fact]
        /*The gross amount is the result after multiplying HoursWorked and HourRate*/
        public void Should_calculate_the_gross_amount_if_employee_has_hourworked_and_hourRate()
        {
            var HourWorked = 60;
            var HourRate = 10;
            var GermanyEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromGermany calculate = new CalculateSalaryFromGermany(GermanyEmployee);
            var GrossAmountTemplate = HourRate * HourWorked;
            Assert.Equal(calculate.GrossAmount, GrossAmountTemplate);
        }
    }
}
