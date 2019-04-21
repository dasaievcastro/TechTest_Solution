using System;
using TechTest_Domain.Builders.Employees;
using TechTest_Domain.Classes.CalculateSalaries.Ireland;
using TechTest_Domain.Classes.Employees;
using Xunit;

namespace TechtTest_Test
{
    public class CalculateSalaryFromIrelandTest
    {
        public CalculateSalaryFromIrelandTest()
        {
        }

        [Fact]
        /*The gross amount is the result after multiplying HoursWorked and HourRate*/
        public void Should_calculate_the_gross_amount_if_employee_has_hourworked_and_hourRate()
        {
            var HourWorked = 60;
            var HourRate = 10;
            var IrelandEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromIreland calculate = new CalculateSalaryFromIreland(IrelandEmployee);
            var GrossAmountTemplate = HourRate * HourWorked;
            Assert.Equal(calculate.GrossAmount, GrossAmountTemplate);
        }

        [Fact]
        /*income tax at a rate of 25% for the first €600 and 40% thereafter*/
        public void Should_calculate_the_tax_rate_of_25_percent_if_the_grossamount_is_less_than_600_euro()
        {
            var HourWorked = 60;
            var HourRate = 10;
            var IrelandEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromIreland calculate = new CalculateSalaryFromIreland(IrelandEmployee);
            calculate.CalculateTaxRate();
            var TaxeRateAmountTemplate = HourRate * HourWorked * .25;
            Assert.Equal(calculate.TaxRateAmount, TaxeRateAmountTemplate);
        }
    }


}
