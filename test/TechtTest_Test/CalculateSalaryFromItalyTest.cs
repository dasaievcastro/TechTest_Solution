using System;
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

        [Fact]
        /*This is charged at 9% for the first €500 and increases by .1% over every €100 thereafter.*/
        public void Should_calculate_the_social_contribution_tax_of_9_percent_if_the_grossamount_is_less_than_500_euro()
        {
            var HourWorked = 50;
            var HourRate = 10;
            var ItalyEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromItaly calculate = new CalculateSalaryFromItaly(ItalyEmployee);
            calculate.CalculateSocialContribution();
            var SocialTaxAmountTemplate = HourRate * HourWorked * .09;
            Assert.Equal(calculate.SocialTaxAmount, SocialTaxAmountTemplate);
        }

        [Fact]
        /*This is charged at 9% for the first €500 and increases by .1% over every €100 thereafter.*/
        public void Should_calculate_the_social_contribution_tax_of_9_plus_x_percent_if_the_grossamount_is_greater_than_500_euro()
        {
            var HourWorked = 60;
            var HourRate = 10;
            var ItalyEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromItaly calculate = new CalculateSalaryFromItaly(ItalyEmployee);
            calculate.CalculateSocialContribution();
            var GrossAmountTemplate = HourRate * HourWorked;
            float ExtraTax = (GrossAmountTemplate - 500) / 100;
            var SocialTaxAmountTemplate = Math.Round(GrossAmountTemplate * (.09 + (ExtraTax / 100)));
            Assert.Equal(calculate.SocialTaxAmount, SocialTaxAmountTemplate);
        }

        [Fact]
        /*the net amount value */
        public void Should_calculate_the_net_amount()
        {
            var HourWorked = 60;
            var HourRate = 10;
            var ItalyEmployee = BuilderEmployee.Create().EarnsForHour(HourRate).WorkedFor(HourWorked).Build();
            CalculateSalaryFromItaly calculate = new CalculateSalaryFromItaly(ItalyEmployee);
            calculate.CalculateNetAmount();
            var NetAmountTemplate = calculate.GrossAmount - calculate.TaxRateAmount - calculate.SocialTaxAmount - calculate.PensionAmount;
            Assert.Equal(calculate.NetAmount, NetAmountTemplate);
        }
    }
}
