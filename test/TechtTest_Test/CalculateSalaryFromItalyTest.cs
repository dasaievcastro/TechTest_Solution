﻿using System;
using TechTest_Domain.Builders.Employees;
using TechTest_Domain.Classes.CalculateSalaries.Italy;
using Xunit;

namespace TechtTest_Test
{
    public class CalculateSalaryFromItalyTest
    {
        public CalculateSalaryFromItalyTest()
        {
        }

        [Fact]
        /*The gross amount is the result after multiplying HoursWorked and HourRate*/
        public void Should_calculate_the_gross_amount_if_employee_has_hourworked_and_hourRate()
        {
            var HourWorked = 60;
            var HourRate = 10;
            var ItalyEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromItaly calculate = new CalculateSalaryFromItaly(ItalyEmployee);
            var GrossAmountTemplate = HourRate * HourWorked;
            Assert.Equal(calculate.GrossAmount, GrossAmountTemplate);
        }

        [Fact]
        /*income tax at a rate of 25% for the first €600 and 40% thereafter*/
        public void Should_calculate_the_tax_rate_of_25_percenthan()
        {
            var HourWorked = 60;
            var HourRate = 10;
            var ItalyEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromItaly calculate = new CalculateSalaryFromItaly(ItalyEmployee);
            calculate.CalculateTaxRate();
            var TaxeRateAmountTemplate = HourRate * HourWorked * .25;
            Assert.Equal(calculate.TaxRateAmount, TaxeRateAmountTemplate);
        }
    }
}
