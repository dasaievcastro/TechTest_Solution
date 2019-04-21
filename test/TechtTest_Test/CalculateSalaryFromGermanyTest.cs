using System;
using TechTest_Domain.Builders.Employees;
using TechTest_Domain.Classes.CalculateSalaries.Germany;
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

        [Fact]
        /*income tax at a rate of 25% is applied on the first €400 and 32% thereafter*/
        public void Should_calculate_the_tax_rate_of_25_percent_if_the_grossamount_is_less_than_400_euro()
        {
            var HourWorked = 40;
            var HourRate = 10;
            var GermanyEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromGermany calculate = new CalculateSalaryFromGermany(GermanyEmployee);
            calculate.CalculateTaxRate();
            var TaxeRateAmountTemplate = HourRate * HourWorked * .25;
            Assert.Equal(calculate.TaxRateAmount, TaxeRateAmountTemplate);
        }

        [Fact]
        /*income tax at a rate of 25% is applied on the first €400 and 32% thereafter*/
        public void Should_calculate_the_tax_rate_of_32_percent_if_the_grossamount_is_greater_than_400_euro()
        {
            var HourWorked = 41;
            var HourRate = 10;
            var GermanyEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromGermany calculate = new CalculateSalaryFromGermany(GermanyEmployee);
            calculate.CalculateTaxRate();
            var TaxeRateAmountTemplate = HourRate * HourWorked * .32;
            Assert.Equal(calculate.TaxRateAmount, TaxeRateAmountTemplate);
        }

        [Fact]
        /*a compulsory pension contribution of 2% is applied*/
        public void Should_calculate_the_pension_tax_of_2_percent()
        {
            var HourWorked = 60;
            var HourRate = 10;
            var GermanyEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromGermany calculate = new CalculateSalaryFromGermany(GermanyEmployee);
            calculate.CalculatePension();
            var PensionAmountTemplate = HourRate * HourWorked * .02;
            Assert.Equal(calculate.PensionAmount, PensionAmountTemplate);
        }
    }
}
